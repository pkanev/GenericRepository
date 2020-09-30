using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Persistence
{
    public class Repository<TEntity> : IRepostiory<TEntity> where TEntity : class
    {
        protected readonly DbContext Context;

        private DbSet<TEntity> Entities
        {
            get => Context.Set<TEntity>();
        }

        public Repository(DbContext context)
        {
            Context = context;
        }

        public TEntity Get(int id) => Entities.Find(id);

        public async Task<TEntity> GetAsync(int id) => await Entities.FindAsync(id);

        public IEnumerable<TEntity> GetAll() => Entities.ToList();

        public async Task<IEnumerable<TEntity>> GetAllAsync() => await Entities.ToListAsync();

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate) => Entities.Where(predicate);

        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate) => Entities.SingleOrDefault(predicate);

        public async Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate) => await Entities.SingleOrDefaultAsync(predicate);

        public void Add(TEntity entity) => Entities.Add(entity);

        public async Task AddAsync(TEntity entity) => await Entities.AddAsync(entity);

        public void AddRange(IEnumerable<TEntity> entities) => Entities.AddRange(entities);

        public async Task AddRangeAsync(IEnumerable<TEntity> entities) => await Entities.AddRangeAsync(entities);

        public void Remove(TEntity entity) => Entities.Remove(entity);

        public void RemoveRange(IEnumerable<TEntity> entities) => Entities.RemoveRange(entities);
    }
}

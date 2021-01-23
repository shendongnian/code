    public class MyDataContext : DbContext
    {
        public MyDataContext() : base("ConnectionName") { }
        //Tables
        public DbSet<Event> Events { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public async Task UpdateChildren<T, TProperty>(T parent, Expression<Func<T, IEnumerable<TProperty>>> childSelector, Action<DbContext, T, TProperty> removeAction = null, Action<DbContext, T, TProperty> addAction = null) where T : BaseEntity where TProperty : BaseEntity
        {
            if (parent == null) { throw new ArgumentNullException(nameof(parent)); }            
            if (childSelector == null) { throw new ArgumentNullException(nameof(childSelector)); }
            if (removeAction == null) { removeAction = (db, p, c) => { db.Set<TProperty>().Remove(c); }; }
            if (addAction == null) { addAction = (db, p, c) => { db.Set<TProperty>().AddOrUpdate(c); }; }
            var newChildren = childSelector.Invoke(parent).ToList();
            var existing = await Set<T>().AsNoTracking().Include(childSelector).SingleOrDefaultAsync(x => x.Id == parent.Id);
            if (existing == null)
            {
                foreach (var addedChild in newChildren) { addAction(this, parent, addedChild); }
                return;
            }
            
            var existingChildren = childSelector.Invoke(existing).ToList();
            foreach (var removedChild in existingChildren.Except(newChildren)) { removeAction(this, parent, removedChild);  }
            foreach (var addedChild in newChildren.Except(existingChildren)) { addAction(this, parent, addedChild); }
        }
    }

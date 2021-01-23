    public class MyDataContext : DbContext
    {
        public MyDataContext() : base("ConnectionName") { }
        //Tables
        public DbSet<Event> Events { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public async Task AddOrUpdate<T>(T entity) where T : BaseEntity
        {
            if (Entry(entity).State == EntityState.Added || Entry(entity).State == EntityState.Modified) { return; }
            var state = await Set<T>().AnyAsync(x => x.Id == entity.Id) ? EntityState.Modified : EntityState.Added;
            Entry(entity).State = state;
            var type = entity.GetType();
            var method = typeof(MyDataContext).GetMethod("AddOrUpdate");
            var properties = type.GetProperties().Where(x => typeof(BaseEntity).IsAssignableFrom(x.PropertyType));
            foreach (var property in properties)
            {
                var generic = method.MakeGenericMethod(property.PropertyType);
                await (Task)generic.Invoke(this, new[] { property.GetValue(entity) });
            }
            method = typeof(MyDataContext).GetMethod("UpdateChildren");
            properties = type.GetProperties().Where(x => typeof(IEnumerable<BaseEntity>).IsAssignableFrom(x.PropertyType));
            foreach (var property in properties)
            {
                var objType = property.PropertyType.GetGenericArguments()[0];
                var enumerable = typeof(IEnumerable<>).MakeGenericType(objType);
                var param = Expression.Parameter(typeof(T), "x");
                var body = Expression.Property(param, property);
                var lambda = Expression.Lambda(Expression.Convert(body, enumerable), param);
                var generic = method.MakeGenericMethod(type, objType);
                await (Task)generic.Invoke(this, new object[] { entity, lambda, null });
            }
        }
        public async Task UpdateChildren<T, TProperty>(T parent, Expression<Func<T, IEnumerable<TProperty>>> childSelector, IEqualityComparer<TProperty> comparer = null) where T : BaseEntity where TProperty : BaseEntity
        {
            var children = (childSelector.Invoke(parent) ?? Enumerable.Empty<TProperty>()).ToList();
            foreach (var child in children) { await AddOrUpdate(child); }
            var existingChildren = await Set<T>().Where(x => x.Id == parent.Id).SelectMany(childSelector).AsNoTracking().ToListAsync();
            if (comparer == null) { comparer = new BaseEntityComparer(); }
            foreach (var child in existingChildren.Except(children, comparer)) { Entry(child).State = EntityState.Deleted; }
        }
    }

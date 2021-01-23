    public class MyDataContext : DbContext
    {
        public MyDataContext() : base("ConnectionName") { }
        //Tables
        public DbSet<Event> Events { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public async Task AddOrUpdate<T>(T entity, params string[] ignoreProperties) where T : BaseEntity
        {
            if (entity == null || Entry(entity).State == EntityState.Added || Entry(entity).State == EntityState.Modified) { return; }
            var state = await Set<T>().AnyAsync(x => x.Id == entity.Id) ? EntityState.Modified : EntityState.Added;
            Entry(entity).State = state;
            var type = typeof(T);
            RelationshipManager relationship;
            var stateManager = ((IObjectContextAdapter)this).ObjectContext.ObjectStateManager;
            if (stateManager.TryGetRelationshipManager(entity, out relationship))
            {
                foreach (var end in relationship.GetAllRelatedEnds())
                {
                    var isForeignKey = end.GetType().GetProperty("IsForeignKey", BindingFlags.Instance | BindingFlags.NonPublic)?.GetValue(end) as bool?;
                    var navigationProperty = end.GetType().GetProperty("NavigationProperty", BindingFlags.Instance | BindingFlags.NonPublic)?.GetValue(end);
                    var propertyName = navigationProperty?.GetType().GetProperty("Identity", BindingFlags.Instance | BindingFlags.NonPublic)?.GetValue(navigationProperty) as string;
                    if (string.IsNullOrWhiteSpace(propertyName) || ignoreProperties.Contains(propertyName)) { continue; }
                    var property = type.GetProperty(propertyName);
                    if (property == null) { continue; }
                    if (end is IEnumerable) { await UpdateChildrenInternal(entity, property, isForeignKey == true); }
                    else { await AddOrUpdateInternal(entity, property, ignoreProperties); }
                }
            }
            if (state == EntityState.Modified)
            {
                Entry(entity).OriginalValues.SetValues(await Entry(entity).GetDatabaseValuesAsync());
                Entry(entity).State = AuditLogDetail.GetChangedProperties(Entry(entity)).Any() ? state : EntityState.Unchanged;
            }
        }
        private async Task AddOrUpdateInternal<T>(T entity, PropertyInfo property, params string[] ignoreProperties)
        {
            var method = typeof(EasementDataContext).GetMethod("AddOrUpdate");
            var generic = method.MakeGenericMethod(property.PropertyType);
            await (Task)generic.Invoke(this, new[] { property.GetValue(entity), ignoreProperties });
        }
        private async Task UpdateChildrenInternal<T>(T entity, PropertyInfo property, bool isForeignKey)
        {
            var type = typeof(T);
            var method = isForeignKey ? typeof(EasementDataContext).GetMethod("UpdateForeignChildren") : typeof(EasementDataContext).GetMethod("UpdateChildren");
            var objType = property.PropertyType.GetGenericArguments()[0];
            var enumerable = typeof(IEnumerable<>).MakeGenericType(objType);
            var param = Expression.Parameter(type, "x");
            var body = Expression.Property(param, property);
            var lambda = Expression.Lambda(Expression.Convert(body, enumerable), property.Name, new[] { param });
            var generic = method.MakeGenericMethod(type, objType);
            await (Task)generic.Invoke(this, new object[] { entity, lambda, null });
        }
        public async Task UpdateForeignChildren<T, TProperty>(T parent, Expression<Func<T, IEnumerable<TProperty>>> childSelector, IEqualityComparer<TProperty> comparer = null) where T : BaseEntity where TProperty : BaseEntity
        {
            var children = (childSelector.Invoke(parent) ?? Enumerable.Empty<TProperty>()).ToList();
            foreach (var child in children) { await AddOrUpdate(child); }
            var existingChildren = await Set<T>().Where(x => x.Id == parent.Id).SelectMany(childSelector).AsNoTracking().ToListAsync();
            if (comparer == null) { comparer = new BaseEntityComparer(); }
            foreach (var child in existingChildren.Except(children, comparer)) { Entry(child).State = EntityState.Deleted; }
        }
        public async Task UpdateChildren<T, TProperty>(T parent, Expression<Func<T, IEnumerable<TProperty>>> childSelector, IEqualityComparer<TProperty> comparer = null) where T : BaseEntity where TProperty : BaseEntity
        {
            var stateManager = ((IObjectContextAdapter)this).ObjectContext.ObjectStateManager;
            var currentChildren = childSelector.Invoke(parent) ?? Enumerable.Empty<TProperty>();
            var existingChildren = await Set<T>().Where(x => x.Id == parent.Id).SelectMany(childSelector).AsNoTracking().ToListAsync();
            if (comparer == null) { comparer = new BaseEntityComparer(); }
            var addedChildren = currentChildren.Except(existingChildren, comparer).AsEnumerable();
            var deletedChildren = existingChildren.Except(currentChildren, comparer).AsEnumerable();
            foreach (var child in currentChildren) { await AddOrUpdate(child); }
            foreach (var child in addedChildren) { stateManager.ChangeRelationshipState(parent, child, childSelector.Name, EntityState.Added); }
            foreach (var child in deletedChildren)
            {
                Entry(child).State = EntityState.Unchanged;
                stateManager.ChangeRelationshipState(parent, child, childSelector.Name, EntityState.Deleted);
            }
        }
    }

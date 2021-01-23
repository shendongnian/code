     public static void AddRangeIgnore(this DbSet dbSet, IEnumerable<object> entities)
        {
            var entitiesList = entities.ToList();
            var firstEntity = entitiesList.FirstOrDefault();
            if (firstEntity == null || !firstEntity.HasKey() || firstEntity.HasIdentityKey())
            {
                dbSet.AddRange(entitiesList);
                return;
            }
            var uniqueEntities = new List<object>();
            using (var dbContext = _dataService.CreateDbContext())
            {
                var uniqueDbSet = dbContext.Set(entitiesList.First().GetType());
                foreach (object entity in entitiesList)
                {
                    var keyValues = entity.GetKeyValues();
                    var existingEntity = uniqueDbSet.Find(keyValues);
                    if (existingEntity == null)
                    {
                        uniqueEntities.Add(entity);
                        uniqueDbSet.Attach(entity);
                    }
                }
            }
            dbSet.AddRange(uniqueEntities);
        }
        public static object[] GetKeyValues(this object entity)
        {
            using (var dbContext = _dataService.CreateDbContext())
            {
                var entityType = entity.GetType();
                dbContext.Set(entityType).Attach(entity);
                var objectStateEntry = ((IObjectContextAdapter)dbContext).ObjectContext.ObjectStateManager.GetObjectStateEntry(entity);
                var value = objectStateEntry.EntityKey
                                            .EntityKeyValues
                                            .Select(kv => kv.Value)
                                            .ToArray();
                return value;
            }
        }
        public static bool HasKey(this object entity)
        {
            using (var dbContext = _dataService.CreateDbContext())
            {
                var entityType = entity.GetType();
                dbContext.Set(entityType).Attach(entity);
                var objectStateEntry = ((IObjectContextAdapter)dbContext).ObjectContext.ObjectStateManager.GetObjectStateEntry(entity);
                return objectStateEntry.EntityKey != null;
            }
        }
        public static bool HasIdentityKey(this object entity)
        {
            using (var dbContext = _dataService.CreateDbContext())
            {
                var entityType = entity.GetType();
                dbContext.Set(entityType).Attach(entity);
                var objectStateEntry = ((IObjectContextAdapter)dbContext).ObjectContext.ObjectStateManager.GetObjectStateEntry(entity);
                var keyPropertyName = objectStateEntry.EntityKey
                                            .EntityKeyValues
                                            .Select(kv => kv.Key)
                                            .FirstOrDefault();
                if (keyPropertyName == null)
                {
                    return false;
                }
                var keyProperty = entityType.GetProperty(keyPropertyName);
                var attribute = (DatabaseGeneratedAttribute)Attribute.GetCustomAttribute(keyProperty, typeof(DatabaseGeneratedAttribute));
                return attribute != null && attribute.DatabaseGeneratedOption == DatabaseGeneratedOption.Identity;
            }
        }

        /// <summary>
        /// Makes a shallow copy of an entity object. This works much like a MemberwiseClone
        /// but directly instantiates a new object and copies only properties that work with
        /// EF and don't have the NotMappedAttribute.
        /// </summary>
        /// <typeparam name="TEntity">The entity type.</typeparam>
        /// <param name="source">The source entity.</param>
        public static TEntity ShallowCopyEntity<TEntity>(TEntity source) where TEntity : class, new()
        {
            // Get properties from EF that are read/write and not marked witht he NotMappedAttribute
            var sourceProperties = typeof(TEntity)
                                    .GetProperties()
                                    .Where(p => p.CanRead && p.CanWrite &&
                                                p.GetCustomAttributes(typeof(System.ComponentModel.DataAnnotations.NotMappedAttribute), true).Length == 0);
            var newObj = new TEntity();
            foreach (var property in sourceProperties)
            {
                // Copy value
                property.SetValue(newObj, property.GetValue(source, null), null);
            }
            return newObj;
        }

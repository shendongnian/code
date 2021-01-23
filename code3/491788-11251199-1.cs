    public static class ObjectContextExtensions
        {
            public static ObjectQuery<TEntity> GetEntities<TEntity>(this ObjectContext context) where TEntity : class {
                var query = from pd in context.GetType().GetProperties()
                            where pd.PropertyType.IsSubclassOf(typeof(ObjectQuery<TEntity>))
                            select (ObjectQuery<TEntity>)pd.GetValue(context, null);
                return query.FirstOrDefault();
            }
        }

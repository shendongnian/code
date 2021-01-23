    using System.Data.Entity.Core.Objects;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    
    namespace System.Data.Entity
    {
        public static class DbContextExtensions
        {
            /// <summary>
            /// Refresh non-detached entities
            /// </summary>
            /// <param name="dbContext">context of the entities</param>
            /// <param name="refreshMode">store or client wins</param>
            /// <param name="entityType">when specified only entities of that type are refreshed. when null all non-detached entities are modified</param>
            /// <returns></returns>
            public static DbContext RefreshEntites(this DbContext dbContext, RefreshMode refreshMode, Type entityType)
            {
                //https://christianarg.wordpress.com/2013/06/13/entityframework-refreshall-loaded-entities-from-database/
                var objectContext = ((IObjectContextAdapter)dbContext).ObjectContext;
                var refreshableObjects = objectContext.ObjectStateManager
                    .GetObjectStateEntries(EntityState.Added | EntityState.Deleted | EntityState.Modified | EntityState.Unchanged)
                    .Where(x => entityType == null || x.Entity.GetType() == entityType)
                    .Where(entry => entry.EntityKey != null)
                    .Select(e => e.Entity)
                    .ToArray();
    
                objectContext.Refresh(RefreshMode.StoreWins, refreshableObjects);
    
                return dbContext;
            }
    
            public static DbContext RefreshAllEntites(this DbContext dbContext, RefreshMode refreshMode)
            {
                return RefreshEntites(dbContext: dbContext, refreshMode: refreshMode, entityType: null); //null entityType is a wild card
            }
    
            public static DbContext RefreshEntites<TEntity>(this DbContext dbContext, RefreshMode refreshMode)
            {
                return RefreshEntites(dbContext: dbContext, refreshMode: refreshMode, entityType: typeof(TEntity));
            }
        }
    }

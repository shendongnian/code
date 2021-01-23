        public static void EvictAll<T>(this ISession session, Predicate<T> predicate = null)
        {
            if (predicate == null)
                predicate = x => true;
            foreach (var entity in session.CachedEntities<T>().Where(predicate.Invoke).ToArray())
                session.Evict(entity);
        }
        public static IEnumerable<T> CachedEntities<T>(this ISession session)
        {
            var sessionImplementation = session.GetSessionImplementation();
            var entities = sessionImplementation.PersistenceContext.EntityEntries.Keys.OfType<T>();
            return entities;
        }

        public static T NewRow<T>(this System.Data.Entity.DbSet<T> entity) where T : class, new()
        {
            T t = new T();
            entity.Add(t);
            return t;
        }

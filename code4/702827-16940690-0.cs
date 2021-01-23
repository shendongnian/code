        public DbEntityEntry<T> EnsureAttachedEF(T entity)
        {
            var e = m_Context.Entry(entity);
            if (e.State == EntityState.Detached)
            {
                m_Context.Set<T>().Attach(entity);
                e = m_Context.Entry(entity);
            }
            return e;
        }

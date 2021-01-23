        public void AttachAndMarkAs<T>(T entity, EntityState state, Func<T, object> id) where T : class
        {
            var entry = Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                var set = Set<T>();
                T attachedEntity = set.Find(id(entity));
                if (attachedEntity != null)
                {
                    var attachedEntry = Entry(attachedEntity);
                    attachedEntry.CurrentValues.SetValues(entity);
                }
                else
                {
                    entry.State = state;
                }
            }
        }

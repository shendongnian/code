            var entry = _dbContext.Entry<T>(entity);
            // Retreive the Id through reflection
            var pkey = _dbset.Create().GetType().GetProperty("Id").GetValue(entity);
            if (entry.State == EntityState.Detached)
            {
                var set = _dbContext.Set<T>();
                T attachedEntity = set.Find(pkey);  // You need to have access to key
                if (attachedEntity != null)
                {
                    var attachedEntry = _dbContext.Entry(attachedEntity);
                    attachedEntry.CurrentValues.SetValues(entity);
                }
                else
                {
                    entry.State = EntityState.Modified; // This should attach entity
                }
            }

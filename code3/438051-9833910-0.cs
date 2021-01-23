    public static void SafeAttachTo<T>(this ObjectContext context, string entitySetName, ref T entity) where T : class {
                ObjectStateEntry entry;
                bool isDetached;
    
                if (context.ObjectStateManager.TryGetObjectStateEntry(context.CreateEntityKey(entitySetName, entity), out entry)) {
                    isDetached = entry.State == EntityState.Detached;
                    entity = (T) entry.Entity;
                }
                else
                    isDetached = true;
    
                if (isDetached)
                    context.AttachTo(entitySetName, entity);
            }

    var attachedEntity = context.ChangeTracker.Entries<T>().FirstOrDefault(x => x.Entity.Id == entity.Id);
    
                    // If the entity is already attached. 
                    if (attachedEntity != null)
                    {
                        // Set new values
                        attachedEntity.CurrentValues.SetValues(entity);
                    }
                    else
                    {
                        // Else attach the entity (if needed)
                        if (context.Entry(entity).State == EntityState.Detached)
                        {
                            Entities.Attach(entity);
                        }
                        // Set the entity's state to modified
                        context.Entry(entity).State = EntityState.Modified;
                    }
                    context.SaveChanges();

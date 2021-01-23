    var articles = ctx.ObjectStateManager
                        // Get all entries for added/changed/modified entities
                        .GetObjectStateEntries(EntityState.Added |
                                               EntityState.Unchanged |
                                               EntityState.Modified)
                        // select the entity objects from the entries
                        .Select(entry=>entry.Entity)
                        // we're only interested in Article objects
                        .OfType<Article>();

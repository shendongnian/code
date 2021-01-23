    public override void Update(T entity) where T : IEntity {
        if (entity == null) {
            throw new ArgumentException("Cannot add a null entity.");
        }
    
        var entry = _context.Entry<T>(entity);
    
        if (entry.State == EntityState.Detached) {
            var set = _context.Set<T>();
            T attachedEntity = set.Find(entity.Id);  // You need to have access to key
    
            if (attachedEntity != null) {
                var attachedEntry = _context.Entry(attachedEntity);
                attachedEntry.CurrentValues.SetValues(entity);
            } else {
                entry.State = EntityState.Modified; // This should attach entity
            }
        }
    enter code here

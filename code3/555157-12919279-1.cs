    public static void ClearReferences(this EntityObject entity) {
        if (entity == null)
            return;
        foreach (var p in entity.GetType().GetProperties()) {
            if (p.PropertyType.IsGenericType) {
                    
                var propertyType = p.PropertyType.GetGenericTypeDefinition();
                if (propertyType == typeof(EntityReference<>)) {
                    var reference = p.GetValue(entity) as dynamic;
                    if (reference.EntityKey != null) {
                        reference.EntityKey = null;
                        ((EntityObject) reference.Value).ClearReferences();
                    }
                }
                if (propertyType == typeof(EntityCollection<>)) {
                    var children = (p.GetValue(entity) as IEnumerable<EntityObject>).ToList(); // covariance
                    foreach (var child in children)
                        child.ClearReferences();
                }
            }
        }
    }

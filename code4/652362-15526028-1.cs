    public bool Save<T>(T entity)
    {
        // Check if "entity" is of type "SpecificClass"
        if (entity is SpecificClass)
        {
            // Entity can be safely casted to "SpecificClass"
            return SaveSpecificClass((SpecificClass)entity);
        }
        
        // ... other cases ...
    }

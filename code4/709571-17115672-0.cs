    public bool Update<T>(int id, Action<T> updateMethod)
        // where T  : SomeDbEntityType
    {
        T entity = LoadFromDatabase(id); // Load your "person" or whatever
        if (entity == null) 
            return false; // If you want to support fails this way, etc...
        // Calls the method on the person
        updateMethod(entity);
        SaveEntity(entity); // Do whatever you need to persist the values
        return true;
    }

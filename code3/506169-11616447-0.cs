    public T AccessEntityById(string Id)
    {
        return AccessEntity(Id, null);
    }
    
    public T AccessEntityByFile(string file)
    {
        return AccessEntity(null, file);
    }

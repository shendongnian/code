    //In engine:
    public T GetEntity<T>(int index) where T : Entity2D
    { 
        return objects[index] as T;
    }
    //Somewhere else:
    Enemy e = GetEntity<Enemy>(0);

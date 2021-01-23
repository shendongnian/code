    interface IUpdateable
    {
    void Update(IUpdateable updated)
    }
    
    public void Update<T>(T updated) where T:IUpdateable
    {
    ...
    ...
    }

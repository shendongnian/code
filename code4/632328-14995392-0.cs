    interface IAddable { void Add(object item); }
    ...
    public void TestAdd<T>(T t1, T t2) where T : IAddable
    {
       return t1.Add(t2);
    }

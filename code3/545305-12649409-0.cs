    public void DoSomething<T,U>(T val) where T : IEnumerable<U>
    {
        foreach (U a in val)
        {
        }
    }

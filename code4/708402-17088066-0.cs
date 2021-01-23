    using (ISomeClient client = InjectedFunc())
    {
        ...
    }
    public delegate Func<ISomeClient> InjectedFunc();
    
    ...

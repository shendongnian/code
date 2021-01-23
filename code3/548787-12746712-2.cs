    public void Add(Type t)
    {
        if (t.GetInterfaces().Contains(typeof(ICanBeHeldInZooCage)))
            _types.Add(t);
    }

    public override string ToString()
    {
        var props = GetType().GetProperties();
        foreach(var prop in props)
            ...
    }

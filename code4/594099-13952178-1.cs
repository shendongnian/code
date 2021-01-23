    public MyObject Create(string pattern)
    {
        Type t = Type.GetType(pattern);
        if (t == null) {
            throw new Exception("Type " + pattern + " not found.");
        }
        return Activator.CreateInstance(t);
    }

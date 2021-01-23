    public MyObject Create(string pattern)
    {
        Type[] types = Assembly.GetExecutingAssembly().GetTypes();
        foreach (Type type in types.Where(t => t.IsSubclassOf(typeof(MyObject))))
        {
            MyObject obj = (MyObject)Activator.CreateInstance(type);
            if (obj.name == pattern)
            {
                return obj;
            }
        }
        throw new Exception("Type " + pattern + " not found.");
    }

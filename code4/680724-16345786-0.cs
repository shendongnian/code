    private static Dictionary<string, object> _assembly = new Dictionary<string,object>();
    public static Assembly getAssembly (string type)
    {
        return _assembly[type] as Assembly;
    }
    public static void addAssembly(string myType, Assembly assembly)
    {
        bool containsKey = _assembly.ContainsKey(myType);
        if (!containsKey)
        {
            _assembly.Add(myType, assembly);
        }
    }

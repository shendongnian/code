    [STAThread]
    public static void Main()
    {
        List<Type> list;
        Stopwatch watch = Stopwatch.StartNew();
        for (Int32 i = 0; i < 100000; ++i)
            list = GetTypesWithMyAttribute(Assembly.GetExecutingAssembly());
        watch.Stop();
        Console.WriteLine("ForEach: " + watch.ElapsedMilliseconds);
        watch.Restart();
        for (Int32 i = 0; i < 100000; ++i)
            list = GetTypesWithMyAttributeLinq1(Assembly.GetExecutingAssembly());
        Console.WriteLine("Linq 1: " + watch.ElapsedMilliseconds);
        watch.Restart();
        for (Int32 i = 0; i < 100000; ++i)
            list = GetTypesWithMyAttributeLinq2(Assembly.GetExecutingAssembly());
        Console.WriteLine("Linq 2: " + watch.ElapsedMilliseconds);
        Console.Read();
    }
    public static List<Type> GetTypesWithMyAttribute(Assembly assembly)
    {
        List<Type> types = new List<Type>();
        foreach (Type type in assembly.GetTypes())
        {
            if (type.GetCustomAttributes(typeof(MyAttribute), true).Length > 0)
                types.Add(type);
        }
        return types;
    }
    public static List<Type> GetTypesWithMyAttributeLinq1(Assembly assembly)
    {
        return assembly.GetTypes()
                   .Where(t => t.GetCustomAttributes().Any(a => a is MyAttribute))
                   .ToList();
    }
    public static List<Type> GetTypesWithMyAttributeLinq2(Assembly assembly)
    {
        return assembly.GetTypes()
                   .Where(t => Attribute.IsDefined(t, typeof(MyAttribute)))
                   .ToList();
    }

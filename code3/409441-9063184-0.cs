    static void ReportTypeProperties<T>(T obj)
    {
        Console.WriteLine("Compile-time type: {0}", typeof(T).Name);
        Console.WriteLine("Actual type: {0}", obj.GetType().Name);
        Console.WriteLine("Is smart? {0}", obj is ISmartAnimal);
    }

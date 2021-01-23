    var dict = new Dictionary<string, int>();
        Type type = dict.GetType();
        Console.WriteLine("Type arguments:");
        foreach (Type arg in type.GetGenericArguments())
        {
            Console.WriteLine("  {0}", arg);
        }

    Type[] types = typeof(IDictionary<,>).GetClosingArguments<MyDictionary>();
    if (types != null)
    {
        foreach (Type t in types)
            Console.WriteLine(t.Name);
    }

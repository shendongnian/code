    dynamic example = new
    {
        a = 3,
        b = "hello"
    };
    foreach (PropertyInfo p in example.GetType().GetProperties())
    {
        string key = p.Name;
        dynamic value = p.GetValue(example, null);
        Console.WriteLine("{0}: {1}", key, value);
    }

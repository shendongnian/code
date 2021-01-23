    Assembly a = Assembly.GetExecutingAssembly();
    foreach (string s in a.GetManifestResourceNames())
    {
        Console.WriteLine(s);
    }
    Console.ReadKey();

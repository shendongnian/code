    foreach (Type type in Assembly.LoadFrom(@"C:\ClassLibrary1.dll").GetTypes())
    {
         MyAttribute1 attribute = type.GetCustomAttributes(false)
                                      .Cast<MyAttribute1>()
                                      .SingleOrDefault();
        if (attribute != null)
        {
           Console.WriteLine(type.Name);
        }
    }

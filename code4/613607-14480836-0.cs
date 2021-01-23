    if (ConfigurationManager.ConnectionStrings != null ) {
        Console.WriteLine(ConfigurationManager.ConnectionStrings.Count);
        Console.WriteLine(ConfigurationManager.ConnectionStrings[0].ConnectionString);
        Console.WriteLine(ConfigurationManager.ConnectionStrings[0].Name);
        ....
    } else {
        Console.WriteLine("null");
    }

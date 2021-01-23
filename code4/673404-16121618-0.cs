    List<Module> modules = new List<Module>();
    while (!reader.EndOfStream)
    {
        lineFromFile = reader.ReadLine();
    
        split = lineFromFile.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
    
        var newModule = new Module();
        newModule.Property1 = split[0];
        newModule.Property2 = split[1];
    
        // (...) //
    
        modules.Add(newModule);
    
    }

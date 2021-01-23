    var customTypesAssembly = typeof(CustomClass).Assembly;
    var filteredDictionary = dictionary.Where(x => x.Value.GetType().Assembly == customTypesAssembly)
        .ToDictionary(x => x.Key, x => x.Value);
    
    var json = JsonConvert.SerializeObject(filteredDictionary);

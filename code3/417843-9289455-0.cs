    Dictionary<string, Property> properties = new Dictionary<string, Property>();
    
    //you add it like that:
    properties[prop.Name] = prop;
    //then access it like that:
    var myColor = properties["Color"];

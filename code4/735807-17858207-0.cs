    var container = JsonConvert.DeserializeObject<ContainerClass>(json);
    JContainer content = (JContainer)container.ClassContent;
    
    switch(container.ClassType)
    {
        case "Class1": return container.ToObject(typeof(ClassOne));
        ..    
    }

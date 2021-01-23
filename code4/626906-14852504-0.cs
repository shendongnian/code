    // inside your actual factoryMethod...
    var lines = ...;
    foreach(var line in lines)
    {
        var tokens = line.Split(',');
        // for split: you can also specify the max. amount of items if the ..... part can
        // consist of more the dots.
        
        CreateMessageObject(tokens); // eventually add to list of AbstractMessage or whatever
    }
    static FactoryClassConstructor()
    {
         _typeMap = new Dictionary<string, Type>();
         _typeMap.Add("Message1000", typeof(Message1000));
         // todo: add other message types
         // you also could write a method which will use the class name of the 
         // type returned by typeof(XYZ) to assure the correct value as key
    }
    private Dictionary<string, Type> _typeMap;
    
    private AbstractMessage CreateMessageObject(string[] tokens)
    {
        // simple error checking
        if(tokens.Count != 5)
            // todo: error handling
            return null;
        var type = typeMap[tokens[0]];
        var instance = Activator.CreateInstance(type);
        instance.Date = DateTime.Parse(tokens[1]);
        instance.Time = DateTime.Parse(tokens[2]);
        // todo initialize other properties
    }

    var hardCodedWorking = Type.GetType("System.String");
    
    var stringName = "String";
    var concatenatedWorking = Type.GetType("System." + stringName);
    
    var badStringName = "string";
    var concatenatedNull = Type.GetType("System." + badStringName);

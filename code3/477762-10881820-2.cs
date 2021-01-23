    //add more .Net BCL names as necessary
    var systemNames = new HashSet<string>
    {
        "mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089",
        "System.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
        ...
    };
    var isSystemType = systemNames.Contains(objToTest.GetType().Assembly.FullName); 

    // load assembly
     System.Reflection.Assembly ass = System.Reflection.Assembly.LoadFrom(@"M:\Programming\se2\se2\bin\Debug\se2.exe");
    // load Settings2 class and default object
    Type settingsType = ass.GetType("se2.Settings2");
    System.Reflection.PropertyInfo defaultProperty = settingsType.GetProperty("Default");
    object defaultObject = defaultProperty.GetValue(settingsType, null);
    // invoke the MyParameter property from the default settings
    System.Reflection.PropertyInfo parameterProperty = settingsType.GetProperty("MyParameter");
    string parameterValue = (string)parameterProperty.GetValue(defaultObject, null);

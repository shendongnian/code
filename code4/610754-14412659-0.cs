    string myType = "MyAssembly.MyType";
     
    Assembly asm = Assembly.LoadFrom("MyAssembly.dll"); // creating instance by loading from other assembly
    //Assembly asm = Assembly.GetExecutingAssembly();  // for creating instance from same assembly
    //Assembly asm = Assembly.GetEntryAssembly(); // for creating instance from entry assembly
    Type t = asm.GetType(myType);
     
    Object obj = Activator.CreateInstance(t, null, null);

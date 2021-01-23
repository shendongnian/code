    // Gets a reference to the same assembly that 
    // contains the type that is creating the ResourceManager.
    System.Reflection.Assembly myAssembly = typeof(Program).Assembly;
    
    // Gets a reference to a different assembly.
    System.Reflection.Assembly myOtherAssembly;
    myOtherAssembly = System.Reflection.Assembly.Load("ResourceAssembly");
    
    // Creates the ResourceManager.
    System.Resources.ResourceManager myManager = new 
       System.Resources.ResourceManager("ResourceNamespace.myResources", 
       myAssembly);
    
    // Retrieves String and Image resources.
    UnmanagedMemoryStream x = myManager.GetStream("StringResource");

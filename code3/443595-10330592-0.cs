    MethodInfo mi = default(MethodInfo);
    
    // Loading the assembly  
    Assembly reflectionAssemby = Assembly.LoadFile(@"C:\RelectionDLL.dll");
    
    // Get type of class from loaded assembly 
    Type reflectionClassType = reflectionAssemby.GetType("ReflectionDLL.ReflectionClass");
    
    // Create instance of the class 
    object objReflection = Activator.CreateInstance(reflectionClassType);
    
    mi = reflectionClassType.GetMethod("pub_Inst_NoReturn_Function");
    mi.Invoke(objReflection, new object[] { value1, Type.Missing });

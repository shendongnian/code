        // assuming class is in same assembly as this method
        Assembly assembly = Assembly.GetExecutingAssembly();
        // you can choose to get type from an known object instead
        Type type = assembly.GetType("Test.SomeClass");
        object instance = Activator.CreateInstance(type, null);            
        MethodInfo methodInfo = type.GetMethod("SomeMethod");                        
        object[] parameterValues = new object[] { 1 };            
        methodInfo.Invoke(instance, parameterValues);

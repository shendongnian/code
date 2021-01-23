    Assembly assembly = Assembly.LoadFile("myAssembly");
            Type type = assembly.GetType("myAssembly.ClassName");
            if (type != null)
            {
                MethodInfo methodInfo = type.GetMethod("MyMethod");
                if (methodInfo != null)
                {
                    object result = null;
                    ParameterInfo[] parameters = methodInfo.GetParameters();
                    object classInstance = Activator.CreateInstance(type, null);
                    if (parameters.Length == 0)
                    {
                        //This works fine
                        result = methodInfo.Invoke(classInstance, null);
                    }
                    else
                    {
                        object[] parametersArray = new object[] { "Hello" };
    
                        //The invoke does NOT work it throws "Object does not match target type"             
                        result = methodInfo.Invoke(classInstance, parametersArray);
                    }
                }
            }

    var a = Activator.CreateInstance(assemblytype, argtoppass);
                    System.Type type = a.GetType();
                    if (type != null)
                    {
                        string methodName = "methodname";
                        MethodInfo methodInfo = type.GetMethod(methodName);
                        object resultpath = methodInfo.Invoke(a, argtoppass);
    
                        res = (string)resultpath;
    
    
                    }

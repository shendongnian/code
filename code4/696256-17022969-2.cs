    T getInstanceFromAppDomain<T>(ref AppDomain appDomain, 
     string assemblyPath, string className = null) 
        {
            if (string.IsNullOrEmpty(className))
            {
                System.Reflection.Assembly assembly = _asm_resolve(assemblyPath);
                System.Reflection.MethodInfo method = assembly.EntryPoint;
                return (T)appDomain.CreateInstanceFromAndUnwrap(assemblyPath, method.Name);
            }
            else 
            {
                
                return (T)appDomain.CreateInstanceFromAndUnwrap(assemblyPath, className);
                
            }
        }

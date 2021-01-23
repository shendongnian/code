    protected System.Reflection.Assembly _asm_resolve(string assemblyFile)
        {
            return System.Reflection.Assembly.LoadFrom(assemblyFile);
        }
    object getInstanceFromAppDomain(ref AppDomain appDomain, 
      string assemblyPath, string className = null) 
        {
            if (string.IsNullOrEmpty(className))
            {
                System.Reflection.Assembly assembly = _asm_resolve(assemblyPath);
                System.Reflection.MethodInfo method = assembly.EntryPoint;
                
                return appDomain.CreateInstanceFromAndUnwrap(assemblyPath, method.Name);
            }
            else 
            {
                
                return appDomain.CreateInstanceFromAndUnwrap(assemblyPath, className);
                
            }
        }

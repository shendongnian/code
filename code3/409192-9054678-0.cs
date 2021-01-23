     public static Assembly My_AssemblyResolve(object sender, ResolveEventArgs args) 
     {
          string missedAssemblyFullName = args.Name;
          Assembly assembly = Assembly.ReflectionOnlyLoad(missedAssemblyFullName); 
          return assembly
     }

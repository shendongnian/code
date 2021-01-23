    public static class AssemblyResolverFix
    {
      //Looks up the assembly in the set of currently loaded assemblies,
      //and returns it if the name matches. Else returns null.
      public static Assembly HandleAssemblyResolve( object sender, ResolveEventArgs args )
      {
        foreach( var ass in AppDomain.CurrentDomain.GetAssemblies() )
          if( ass.FullName == args.Name )
            return ass;
        return null;
      }
    }
    
    //in main
    AppDomain.CurrentDomain.AssemblyResolve += AssemblyResolverFix.HandleAssemblyResolve;

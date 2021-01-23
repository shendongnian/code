    // Put this in your initialization code
    public static void Main()
    {
        AppDomain.CurrentDomain.AssemblyResolve += new ResolveAssembly(MyResolveEventHandler);
    }
    private static Assembly ResolveAssembly(object sender, ResolveEventArgs e)
    {
        // Clean, check, double check and verify path name to be sure it's a valid
        // assembly name and it's not a relative path itself, you may even check e.RequestingAssembly
        string path = ...; 
  
        return Assembly.LoadFrom(path);
    }

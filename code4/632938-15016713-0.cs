    AppDomain currentDomain = AppDomain.CurrentDomain;
    currentDomain.AssemblyResolve += OnAssemblyResolve;
    
    ...
    
    private static Assembly OnAssemblyResolve(object sender, ResolveEventArgs args)
    {
       Console.WriteLine(args.RequestingAssembly); //set breakpoint there
       return null;
    }

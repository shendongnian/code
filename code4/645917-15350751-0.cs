    AppDomain.CurrentDomain.AssemblyResolve += AssemblyResolve;
    
    private static Assembly AssemblyResolve(object sender, ResolveEventArgs args)
    {
        return AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault(a => a.FullName == args.Name);
    }

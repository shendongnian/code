    AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
        private Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            var domain = (AppDomain)sender;
            var assemblies = domain.GetAssemblies();
            return assemblies.FirstOrDefault(assembly => assembly.GetName().Name == args.Name.Split(',')[0]);
        }

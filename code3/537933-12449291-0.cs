    AppDomain.CurrentDomain.AssemblyResolve += (object sender, ResolveEventArgs args)=>
        {
            string assemblyToResove = args.Name;
            //return Assembly.Load(....);
        };

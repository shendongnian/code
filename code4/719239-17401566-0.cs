    AppDomain.CurrentDomain.AssemblyResolve += (sender, args) =>
        {
            if (args.Name == Assembly.GetAssembly(typeof(ComLib)).FullName) // adapt to your needs
                return Assembly.GetAssembly(typeof(ComLib));
    
            return null;
        };

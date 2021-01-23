    public void AssembleCalculatorComponents()
            {
    
    
                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Plugins");
                Console.WriteLine(path);
                //Check the directory exists
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                Console.WriteLine(path);
                string assemblyName = Assembly.GetEntryAssembly().FullName;
                Console.WriteLine(assemblyName);
                //Create an assembly catalog of the assemblies with exports
                var catalog = new AggregateCatalog(
                    new AssemblyCatalog(Assembly.GetExecutingAssembly().Location),
                    new AssemblyCatalog(Assembly.Load(assemblyName)),
                    new DirectoryCatalog(path, "*.dll"));
    
                //Create a composition container
                var container = new CompositionContainer(catalog);
                container.ComposeParts(this);

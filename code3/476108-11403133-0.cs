       AppDomain currentDomain = AppDomain.CurrentDomain;
       currentDomain.AssemblyResolve += new ResolveEventHandler(MyResolveEventHandler);
    
    
     private Assembly MyResolveEventHandler(object sender, ResolveEventArgs args)
            {
    
                Assembly MyAssembly,objExecutingAssemblies = Assembly.GetExecutingAssembly();
                AssemblyName[] arrReferencedAssmbNames = objExecutingAssemblies.GetReferencedAssemblies();
                if(args.Name.Contains("Coyname.Product.Service.Scheduler"))
                {
                    string assName = Parser.ParseAssemblyNameReference(args.Name);
                    var rootDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                    var pluginDir = Path.Combine(rootDirectory, "Quartz");
                    pluginDir += string.Format("\\{0}.dll",assName);;
                    MyAssembly =  Assembly.LoadFrom(pluginDir); 
                }
                else
                {
                    MyAssembly = Assembly.LoadFrom(string.Empty); 
                }
                return MyAssembly;
    }

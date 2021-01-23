    class AssemblyResolver
      {
        static AssemblyResolver()
        {
          AppDomain.CurrentDomain.AssemblyResolve +=
            (sender, args) =>
              {
                var referencedAssemblies = Assembly.GetExecutingAssembly().GetReferencedAssemblies();
                var instanceName = referencedAssemblies.ToList().First(x => x.FullName == args.Name).Name;
                var loadFile = Assembly.LoadFile(System.IO.Path.GetDirectoryName(Assembly.GetAssembly(typeof(AssemblyResolver)).Location) + @"\" + instanceName + ".dll");
                return loadFile;
              }; 
        }
    
        public AssemblyResolver()
        {
    
        }
    
      }

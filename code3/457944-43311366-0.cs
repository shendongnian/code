    AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
and:
     private static System.Reflection.Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            var probingPath = pathToYourDataFolderHere;
            var assyName = new AssemblyName(args.Name);
            var newPath = Path.Combine(probingPath, assyName.Name);
            if (!newPath.EndsWith(".dll"))
            {
                newPath = newPath + ".dll";
            }
            if (File.Exists(newPath))
            {
                var assy = Assembly.LoadFile(newPath);
                return assy;
            }
            return null;
        }

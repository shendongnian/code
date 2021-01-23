    internal static class Program
    {
        static Program()
        {
            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomainOnAssemblyResolve;
        }
    
        private static void Main()
        {
            //Do your stuff
        }
    
        private static Assembly CurrentDomainOnAssemblyResolve(object sender, ResolveEventArgs args)
        {
            try
            {
                AssemblyName name = new AssemblyName(args.Name);
    
                string expectedFileName = name.Name + ".dll";
                string rootDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
    
                return LoadAssembly(rootDir, expectedFileName, "", "Dlls", "../Dlls");
            }
            catch
            {
                return null;
            }
        }
    
        private static Assembly LoadAssembly(string rootDir, string fileName, params string[] directories)
        {
            foreach (string directory in directories)
            {
                string path = Path.Combine(rootDir, directory, fileName);
                if (File.Exists(path))
                    return Assembly.LoadFrom(path);
            }
            return null;
        }
    }

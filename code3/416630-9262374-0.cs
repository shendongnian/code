    class Program
    {
        static void Main(string[] args)
        {
            var assemblyName = "SimpleAssembly";
            var versionRegex = new Regex(@"^12\.");
            var assemblyFile = FindAssemblyFile(assemblyName, versionRegex);
            if (assemblyFile == null)
                throw new FileNotFoundException();
            Assembly.LoadFile(assemblyFile.FullName);
        }
        static FileInfo FindAssemblyFile(string assemblyName, Regex versionRegex)
        {
            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Windows), "assembly", "GAC_MSIL", assemblyName);
            var assemblyDirectory = new DirectoryInfo(path);
            foreach (var versionDirectory in assemblyDirectory.GetDirectories())
            {
                if (versionRegex.IsMatch(versionDirectory.Name))
                {
                    return versionDirectory.GetFiles()[0];
                }
            }
            return null;
        }
    }

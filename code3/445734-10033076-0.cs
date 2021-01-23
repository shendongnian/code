    public class AssemblyResourceVirtualFile : VirtualFile
    {
        string path;
        public AssemblyResourceVirtualFile(string virtualPath) : base(virtualPath)
        {
            path = VirtualPathUtility.ToAppRelative(virtualPath);
        }
        public override System.IO.Stream Open()
        {
            string[] parts = path.Split('/');
            string assemblyName = parts[2];
            string resourceName = parts[3];
            assemblyName = Path.Combine(HttpRuntime.BinDirectory, assemblyName);
            System.Reflection.Assembly assembly = System.Reflection.Assembly.LoadFile(assemblyName);
            if (assembly != null)
            {
                Stream resourceStream = assembly.GetManifestResourceStream(resourceName);
                return resourceStream;
            }
            return null;
        }
    }

    class Program
    {
        // ... Your code
        [STAThread]
        static void Main(string[] args)
        {
            AppDomain.CurrentDomain.AssemblyResolve += AssemblyResolve;  // Called when the assembly has been successfully resolved
            // ... Your code
        }
        private Assembly AssemblyResolve(object sender, ResolveEventArgs args)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            string assemblyName = args.Name.Split(',')[0];  // Gets the assembly name to resolve.
            using (Stream stream = assembly.GetManifestResourceStream("MyAssembly.MyDlls." + assemblyName + ".dll"))  // Gets the assembly in the embedded resources
            {
                if (stream == null)
                    return null;
                byte[] rawAssembly = new byte[stream.Length];
                stream.Read(rawAssembly, 0, (int)stream.Length); 
                return Assembly.Load(rawAssembly);
            }
        }
    }

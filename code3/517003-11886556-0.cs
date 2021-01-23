    public override System.IO.Stream Open()
            {
                string[] parts = path.Split('/');
                string assemblyName = parts[2];
                string resourceName = parts[3];
    
                
                assemblyName = Path.Combine(HttpRuntime.BinDirectory, assemblyName);
                byte[] assemblyBytes = File.ReadAllBytes(assemblyName);
                System.Reflection.Assembly assembly = Assembly.Load(assemblyBytes);
                /*System.Reflection.Assembly assembly = System.Reflection.Assembly.LoadFile(assemblyName);*/
                if (assembly != null)
                {
                    Stream resourceStream = assembly.GetManifestResourceStream(resourceName);
                    return resourceStream;
                }
                return null;
            }

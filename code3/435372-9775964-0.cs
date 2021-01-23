        static void Main(string[] args)
        {
            string pathToExecutable = "Target.exe";
                        
            byte[] encoding = Encoding.Unicode.GetBytes("<Data><!-- data goes here --></Data>");
                        
            var resource = new EmbeddedResource(
                   "ConfigurationFile", 
                    ManifestResourceAttributes.Private, 
                    encoding);
            
            var asm = AssemblyDefinition.ReadAssembly(pathToExecutable);
            
            asm.Modules.FirstOrDefault().Resources.Add(resource);
            asm.Write(pathToExecutable);
        }

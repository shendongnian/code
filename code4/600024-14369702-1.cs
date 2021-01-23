    var catalog = new AggregateCatalog();
                string dirPath = @".\Extensions";
                foreach (string assemblyFile in Directory.EnumerateFiles(dirPath, "*.dll"))
                {
                    if (AssemblyIncludesCustomAttribute("Blah.dll", "System.Reflection.AssemblyConfigurationAttribute"))
                    {
                        catalog.Catalogs.Add(new AssemblyCatalog(assemblyFile));                    
                    }
                }

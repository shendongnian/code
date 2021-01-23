    var assemblyPath = Path.GetDirectoryName(typeof (ConfigurationTests).Assembly.Location);
                string webConfigPath = MyPath;
                string directory = System.IO.Path.GetFullPath(Path.Combine(assemblyPath,webConfigPath));
                Console.WriteLine(directory);
                Assert.That(Directory.Exists(directory));
    
                VirtualDirectoryMapping vdm = new VirtualDirectoryMapping(directory, true);
                WebConfigurationFileMap wcfm = new WebConfigurationFileMap();
                wcfm.VirtualDirectories.Add("/", vdm);
                System.Configuration.Configuration webConfig = WebConfigurationManager.OpenMappedWebConfiguration(wcfm, "/");
                var connectionString = webConfig.ConnectionStrings.ConnectionStrings["ConnectionString"].ConnectionString;
    
                Console.WriteLine("Connection String:");
                Console.WriteLine(connectionString);
    
                Console.WriteLine("AppSettings:");
                foreach (var key in webConfig.AppSettings.Settings.AllKeys)
                {
                    Console.WriteLine("{0} : {1}", key, webConfig.AppSettings.Settings[key].Value);
                }

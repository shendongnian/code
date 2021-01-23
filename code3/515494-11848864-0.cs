                    /// <summary>
                    /// This class provide inforamtion about product version.
                    /// </summary>
                    public class ProductVersion
                    {
                        private readonly FileVersionInfo fileVersionInfo;
                
                        private readonly AssemblyName assemblyName;
                
                            
                        private ProductVersion(Type type)
                        {
                            // it done this way to prevent situation 
                            // when site has limited permissions to work with assemblies.
                            var assembly = Assembly.GetAssembly(type);
                            fileVersionInfo = FileVersionInfo.GetVersionInfo(assembly.Location);
                            assemblyName = new AssemblyName(assembly.FullName);
                        }
            
                        public string AssemblyFileVersion
                        {
                            get
                            {
                                return fileVersionInfo.FileVersion;
                            }
                        }
                
                        public string AssemblyVersion
                        {
                            get
                            {
                                return assemblyName.Version.ToString();
                            }
                        }
                
                
                        
                    }

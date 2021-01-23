                        AppDomainSetup domainSetup = new AppDomainSetup()
                        {
                            ApplicationBase = _config.ShadowPath
                        };
                        AppDomain domain = AppDomain.CreateDomain(available.Description.ShortName, null, domainSetup);
                        domain.AssemblyResolve += (source, args) =>
                            {
                                int comma = args.Name.IndexOf(',');
                                string path = Path.Combine(Path.GetDirectoryName(Process.GetCurrentProcess().Modules[0].FileName), args.Name.Substring(0, comma) + ".dll");
                                return Assembly.LoadFrom(path);
                            };

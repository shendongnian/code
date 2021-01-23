      if (_loadConfiguration && _configurationFile.Exists && _IsConfigurationFileValid())
                {
                    configuration = _LoadConfigurationFromFile();
                }
                else
                {
                    configuration = Fluently.Configure()
                        .Database(MsSqlConfiguration.MsSql2008
                            .ConnectionString(x => x.FromConnectionStringWithKey("Development"))
                            #if DEBUG
                            .ShowSql()
                            #endif
                        )
                        .ProxyFactoryFactory("NHibernate.Bytecode.DefaultProxyFactoryFactory, NHibernate")
                        .Mappings(mappings => mappings.FluentMappings.AddFromAssemblyOf<UserMap>()
                                                  .Conventions.Setup(MappingConventions.GetConventions()))
                        .Mappings(mappings => mappings.HbmMappings.AddFromAssemblyOf<UserMap>())
                        .BuildConfiguration();
    
                    _SaveConfigurationToFile(configuration);
                }
    
      private bool _IsConfigurationFileValid()
            {
                var assInfo = new FileInfo(Assembly.GetCallingAssembly().Location);
                return _configurationFile.LastWriteTime >= assInfo.LastWriteTime;
            }
    
            private void _SaveConfigurationToFile(Configuration configuration)
            {
                //#if DEBUG
                //return;
                //#endif
                _logger.Debug("Starting to save NHibernate configuration to " + _configurationFile.FullName);
                using(var file = _configurationFile.OpenWrite())
                {
                    new BinaryFormatter().Serialize(file, configuration);
                    file.Close();
                }
                _logger.Debug("Finished saving NHibernate configuration to " + _configurationFile.FullName);
            }
    
            private Configuration _LoadConfigurationFromFile()
            {
                //#if DEBUG
                //    return null;
                //#endif
                _logger.Debug("Starting to load NHibernate configuration from " + _configurationFile.FullName);
                using(var file = _configurationFile.OpenRead())
                {
                    var binaryFormatter = new BinaryFormatter();
                    var config = binaryFormatter.Deserialize(file) as Configuration;
                    file.Close();
                    _logger.Debug("Finished loading NHibernate configuration from " + _configurationFile.FullName);
                    return config;
                }
            }

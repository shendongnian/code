     $ Configuration config = ConfigurationManager.OpenExeConfiguration                            (ConfigurationUserLevel.None);
            config.ConnectionStrings.ConnectionStrings.Add(new ConnectionStringSettings(
                                                          "MyConnectionString",
                                                          String.Format("DataSource={0};InitialCatalog={1};IntegratedSecurity={2}",
                                                                         "testing", "testing2", "Testing6")));
            config.Save(ConfigurationSaveMode.Modified, true);
            ConfigurationManager.RefreshSection("connectionStrings");

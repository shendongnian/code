    if (!SimpleIoc.Default.IsRegistered<IDataService>())
                    {
                        switch (DefaultConnectionConfiguration.ConnectionMode)
                        {
                            case DataConnectionMode.WcfService:
                                var wcfServiceConfiguration = (WcfServiceConfiguration)CurrentConnectionConfiguration;
                                SimpleIoc.Default.Register<IDataService>(
                                    () =>
                                    wcfServiceConfiguration != null
                                        ? new DataServiceClient("WSHttpBinding_IDataService",
                                                                     wcfServiceConfiguration.EndpointUrl)
                                        : null);
                                break;
    
                            case DataConnectionMode.Database:
                                SimpleIoc.Default.Register<IDataService, DbClient>();
                                break;
                        }
                    }

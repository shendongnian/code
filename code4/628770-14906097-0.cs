    var connectionStringBuilder = new EntityConnectionStringBuilder
                                                    {
                                                        Metadata = "{metadata}",
                                                        Provider = "{provider}",
                                                        ProviderConnectionString = "{connection string from config}"
                                                    };
    var ctx = new BibliotecaEntities(connectionStringBuilder.ToString());

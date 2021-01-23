        var configFactory = new DataCacheFactoryConfiguration
                                {
                                    Servers =
                                        new List<DataCacheServerEndpoint>
                                            {new DataCacheServerEndpoint(cacheServer, cachePort)},
                                    SecurityProperties =
                                        new DataCacheSecurity(Encryption.CreateSecureString(cacheAuthorization),
                                                              true)
                                };

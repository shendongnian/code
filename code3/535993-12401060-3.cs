            public System.Data.Common.DbProviderFactory GetFactory(Type tAssemblyType)
            {
                return GetFactory(tAssemblyType.AssemblyQualifiedName);
            }
    
    
            public virtual System.Data.Common.DbProviderFactory GetFactory(string assemblyType)
            {
    
    #if TARGET_JVM // case insensitive GetType is not supported
                Type type = Type.GetType (assemblyType, false);
    #else
                Type type = Type.GetType(assemblyType, false, true);
    #endif
                if (type != null && type.IsSubclassOf(typeof(System.Data.Common.DbProviderFactory)))
                {
                    // Provider factories are singletons with Instance field having
                    // the sole instance
                    System.Reflection.FieldInfo field = type.GetField("Instance", System.Reflection.BindingFlags.Public |
                                                     System.Reflection.BindingFlags.Static);
                    if (field != null)
                    {
                        return (System.Data.Common.DbProviderFactory)field.GetValue(null);
                        //return field.GetValue(null) as DbProviderFactory;
                    }
    
                }
    
                throw new System.Configuration.ConfigurationErrorsException("DataProvider is missing!");
                //throw new System.Configuration.ConfigurationException("DataProvider is missing!");
            } // End Function GetFactory

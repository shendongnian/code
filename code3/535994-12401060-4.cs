    public System.Data.Common.DbProviderFactory GetFactory()
            {
                //AddFactoryClasses();
                System.Data.Common.DbProviderFactory providerFactory = null;
                providerFactory = this.GetFactory(typeof(Npgsql.NpgsqlFactory));
    
                return providerFactory;
            } // End Function GetFactory

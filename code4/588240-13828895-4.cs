        public class DataProvider : IDataProvider
        {
            private IConfiguration configuration;
            public DataProvider(IConfiguration configuration)
            {
                this.configuration = configuration;
            }
            private string DefaultConnectionString
            {
                get
                {
                    return configuration.MyConnectionString;
                }
            }
            ...
        }

    public static class FactoryInitializer
    {
        public static IDatabase LoadFactory<T>(string connectionstring) where T : FactoryBase, new()
        {
            var factory = new T();
            var data = factory.GetDataLayer();
            data.ConnectionString = connectionstring;
            return data;
        }
    }

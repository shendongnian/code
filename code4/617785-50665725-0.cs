    public class JsonValueProviderConfig
    {
        public static void Config(ValueProviderFactoryCollection factories)
        {
            var jsonProviderFactory = factories.OfType<JsonValueProviderFactory>().Single();
            factories.Remove(jsonProviderFactory);
            factories.Add(new CustomJsonValueProviderFactory());
        }
    }

    public static class NameValueCollectionExtensions
    {
        public static KeyValueConfigurationCollection CastToConfigurationCollection(this NameValueCollection settings)
        {
            var collection = new KeyValueConfigurationCollection();
            for (int i = 0; i < settings.Count; i++)
            {
                var keyValue = new KeyValueConfigurationElement(settings.Keys[i], settings[i]);
                collection.Add(keyValue);
            }
            return collection;
        }
    }

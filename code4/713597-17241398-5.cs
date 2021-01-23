    public static class ExtensionMethods
    {
        public static TInstanceType DeserializeWithProxy<TProxyType,TInstanceType>(this string xml) 
            where TProxyType : ISerializerProxy<TInstanceType> 
            where TInstanceType : class
        {
            using (XmlReader reader = XDocument.Parse(xml).CreateReader())
            {
                var xmlSerializer = new XmlSerializer(typeof(TProxyType));
                return (xmlSerializer.Deserialize(reader) as ISerializerProxy<TInstanceType>).Value;
            }
        }
    }

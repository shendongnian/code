    public static class MetadataHelper
    {
        public static string GetFirstValueFromMetaDataAttribute<T>(this T value, string metaDataDescription)
        {
            return GetValueFromMetaDataAttribute(value, metaDataDescription).FirstOrDefault();
        }
        private static IEnumerable<string> GetValueFromMetaDataAttribute<T>(T value, string metaDataDescription)
        {
            var attribs =
                value.GetType().GetField(value.ToString()).GetCustomAttributes(typeof (MetadataAttribute), true);
            return attribs.Any()
                ? (from p in (MetadataAttribute[]) attribs
                    where p.Description.ToLower() == metaDataDescription.ToLower()
                    select p.MetaData).ToList()
                : new List<string>();
        }
        public static List<T> GetEnumeratesByMetaData<T>(string metadataDescription, string value)
        {
            return
                typeof (T).GetEnumValues().Cast<T>().Where(
                    enumerate =>
                        GetValueFromMetaDataAttribute(enumerate, metadataDescription).Any(
                            p => p.ToLower() == value.ToLower())).ToList();
        }
        public static List<T> GetNotEnumeratesByMetaData<T>(string metadataDescription, string value)
        {
            return
                typeof (T).GetEnumValues().Cast<T>().Where(
                    enumerate =>
                        GetValueFromMetaDataAttribute(enumerate, metadataDescription).All(
                            p => p.ToLower() != value.ToLower())).ToList();
        }
       
    }

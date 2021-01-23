    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class AutocompleteAttribute : Attribute, IMetadataAware
    {
        public const string Key = "autocomplete-url";
        internal static IDictionary<string, string> Urls { get; private set; }
        static AutocompleteAttribute()
        {
            Urls = new Dictionary<string, string>();
        }
        public void OnMetadataCreated(ModelMetadata metadata)
        {
            metadata.TemplateHint = "Autocomplete";
            string url;
            if (Urls.TryGetValue(metadata.PropertyName, out url))
            {
                metadata.AdditionalValues[Key] = url;
                Urls.Remove(metadata.PropertyName);
            }
        }
    }

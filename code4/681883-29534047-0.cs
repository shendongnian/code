    public static class ResourceManagerHelper
    {
        public static string GetResourceName(this ResourceManager resourceManager, string value, CultureInfo cultureInfo, bool ignoreCase = false)
        {
            var comparisonType = ignoreCase ? System.StringComparison.OrdinalIgnoreCase : System.StringComparison.Ordinal;
            var entry = resourceManager.GetResourceSet(cultureInfo, true, true)
                                       .OfType<DictionaryEntry>()
                                       .FirstOrDefault(dictionaryEntry => dictionaryEntry.Value.ToString().Equals(value, comparisonType));
            if (entry.Key == null)
                throw new System.Exception("Key and value not found in the resource file");
            return entry.Key.ToString();
        }
    }

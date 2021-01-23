    public static class ResourceHelper
    {
        public static string FindNameFromResource(ResourceDictionary dictionary, 
               object resourceItem)
        {
            return (dictionary.Contains(resourceItem)) ? 
                   dictionary[resourceItem].ToString() : 
                   string.Empty;
        }
    }

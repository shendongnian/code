    public static class SearchResultHelper
    {
        public static string GetValue(this SearchResult searchResult, string propertyName)
        {
            return searchResult.Properties.Contains(propertyName) ? searchResult.Properties[propertyName][0].ToString() : string.Empty;
        }
    }

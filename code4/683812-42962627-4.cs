    public static class HeaderParser
    {
    public static PagingInfo FindAndParsePagingInfo(HttpResponseHeaders responseHeaders)
    {
        // find the "X-Pagination" info in header
        if (responseHeaders.Contains("X-Pagination"))
        {
            var xPag = responseHeaders.First(ph => ph.Key == "X-Pagination").Value;
            // parse the value - this is a JSON-string.
            return JsonConvert.DeserializeObject<PagingInfo>(xPag.First());
        }
        return null;
    }
    public static string GetSingleHeaderValue(HttpResponseHeaders responseHeaders, 
        string keyName)
    {
        if (responseHeaders.Contains(keyName))
            return responseHeaders.First(ph => ph.Key == keyName).Value.First();
        return null;
    }
}

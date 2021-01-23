    private string SafeReadContentFrom(HttpRequestMessage request)
    {
         var contentType = request.Content.Headers.ContentType;
         var contentInString = request.Content.ReadAsStringAsync().Result;
         request.Content = new StringContent(contentInString);
         request.Content.Headers.ContentType = contentType;
         return contentInString;
    }

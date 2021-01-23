    private HttpRequestMessage GetPostMessage(string uri, string contentType,
                                              string fileName, Stream content)
    {    
        var request = new HttpRequestMessage
        {
            Content = new StreamContent(content),
            RequestUri = new Uri(uri),
            Method = HttpMethod.Post
        };
        // contentType = "video/mp4"
        request.Content.Headers.ContentType = new MediaTypeHeaderValue(contentType);
        
        //Need TryAddWithoutValidation because of the equals sign in the value.
        request.Content
               .Headers
               .TryAddWithoutValidation("Content-Disposition",
                                        $"attachment; filename=\"{Path.GetFileName(fileName)}\"");
        // If there is no equals sign in your content disposition, this will work:
        // request.Content.Headers.ContentDisposition = 
        //    new ContentDispositionHeaderValue($"attachment; \"{Path.GetFileName(fileName)}\"");
        return request;
    }

    [HttpGet]
    public HttpResponseMessage Generate()
    {
        var stream = new MemoryStream();
        // processing the stream.
    
        var result = new HttpResponseMessage(HttpStatusCode.OK)
        {
            Content = new ByteArrayContent(stream.GetBuffer())
        };
        result.Content.Headers.ContentDisposition =
            new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment")
        {
            FileName = "CertificationCard.pdf"
        };
        result.Content.Headers.ContentType =
            new MediaTypeHeaderValue("application/octet-stream");
    
        return result;
    }

    public virtual IHttpActionResult Get()
    {
        var result = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.OK)
        {
            Content = new System.Net.Http.ByteArrayContent(System.IO.File.ReadAllBytes(@"e:\load.json"))
        };
        result.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
        return ResponseMessage(result);
    }

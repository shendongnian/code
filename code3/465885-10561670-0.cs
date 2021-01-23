    public HttpResponseMessage Get()
    {
        var resp = new HttpResponseMessage()
        {
            Content = new StringContent("{json here...}")
        };
        resp.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
        return resp;
    }

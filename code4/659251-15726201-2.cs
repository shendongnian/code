    public HttpResponseMessage Get()
    {
        var stream = new FileStream(@"c:\data.json", FileMode.Open);
		var result = Request.CreateResponse(HttpStatusCode.OK);
        result.Content = new StreamContent(stream);
        result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
        
		return result;
    }

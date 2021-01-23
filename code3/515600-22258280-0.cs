    [HttpGet]
    public HttpResponseMessage Me(string hash)
    {
        HttpResponseMessage httpResponseMessage;
        List<Something> somethings = ...
        var returnObjects = somethings.Select(x => new {
            Id = x.Id,
            OtherField = x.OtherField
        });
    
        httpResponseMessage = Request.CreateResponse(HttpStatusCode.OK, 
                                     new { result = true, somethings = returnObjects });
    
        return httpResponseMessage;
    }

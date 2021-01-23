    public HttpResponseMessage Get()
    {
        var listInt = new List<int>() { 1, 2 };
        var listString = new List<string>() { "a", "b" };
        return ControllerContext.Request
            .CreateResponse(HttpStatusCode.OK, new { listInt, listString });
    }

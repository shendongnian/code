    public HttpResponseMessage Get()
    {
        var response = Request.CreateResponse((HttpStatusCode)207, "something");
        return response;
    }

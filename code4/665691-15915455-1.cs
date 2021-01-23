    public HttpResponseMessage GetFoo(int id)
    {
        var foo = _FooRepository.GetFoo(id);
        var response = Request.CreateResponse(HttpStatusCode.OK, foo);
        response.Headers.CacheControl = new CacheControlHeaderValue()
            {
                Public = true,
                MaxAge = new TimeSpan(1, 0, 0, 0)
            };
        return response;
    }

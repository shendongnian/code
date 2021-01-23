    [EnableQuery]
    public HttpResponseMessage Get(MyModel model)
    {
        if (!ModelState.IsValid) return Request.CreateResponse((HttpStatusCode)422, "Unprocessable Entity");
        //your-code-here
        return Request.CreateResponse(HttpStatusCode.OK, myEnumerable);
    }

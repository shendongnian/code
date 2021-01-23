    public HttpResponseMessage GetOne()
    {
        return this.Request.CreateResponse(
            HttpStatusCode.OK,
            FunctionOne());
    }
    public HttpResponseMessage GetTwo()
    {
        return this.Request.CreateResponse(
            HttpStatusCode.OK,
            FunctionTwo());
    }

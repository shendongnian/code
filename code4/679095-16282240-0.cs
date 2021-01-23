    public async Task<HttpResponseMessage> PostActionAsync()
    {
        var result = await GetSomeResult();
        return Request.CreateResponse(HttpStatusCode.Created, result);
    }

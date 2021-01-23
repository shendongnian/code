    public HttpResponseMessageGetUser(HttpRequestMessage request, int userId, DateTime lastModifiedAtClient)
    {
        var user = new DataEntities().Users.First(p => p.Id == userId);
        if (user.LastModified <= lastModifiedAtClient)
        {
             return new HttpResponseMessage(HttpStatusCode.NotModified);
        }
        return request.CreateResponse(HttpStatusCode.OK, user);
    }

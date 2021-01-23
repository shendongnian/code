    public HttpResponseMessageGetUser(int userId, DateTime lastModifiedAtClient)
    {
        var user = new DataEntities().Users.First(p => p.Id == userId);
        if (user.LastModified <= lastModifiedAtClient)
        {
             return new HttpResponseMessage(HttpStatusCode.NotModified);
        }
        return Request.CreateResponse(HttpStatusCode.OK, user);
    }

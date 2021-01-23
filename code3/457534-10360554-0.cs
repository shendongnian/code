    public HttpResponseMessage Post(MyResource myResource)
    {
        ...
        if (goodStuff)
        {
            return new HttpResponseMessage<MyResource>(myNewResource, HttpStatusCode.Created);
        }
        else if (badStuff)
        {
            return new HttpResponseMessage<BadRequest>(badRequest, HttpStatusCode.BadRequest);
        }
        else
        {
            return new HttpResponseMessage(HttpStatusCode.InternalServerError);
        }
    }

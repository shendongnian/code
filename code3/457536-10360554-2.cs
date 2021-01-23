    public HttpResponseMessage Post(MyResource myResource)
    {
        ...
        if (goodStuff)
        {
            return ControllerContext.Request.CreateResponse(HttpStatusCode.Created, myNewResource);
        }
        else if (badStuff)
        {
            return ControllerContext.Request.CreateResponse(HttpStatusCode.BadRequest, badRequest);
        }
        else
        {
            return new HttpResponseMessage(HttpStatusCode.InternalServerError);
        }
    }

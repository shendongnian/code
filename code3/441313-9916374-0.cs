    public override void OnActionExecuting(HttpActionContext actionContext)
    {
        if (checkVerified())
        {
            actionContext.Response = 
                new HttpResponseMessage(HttpStatusCode.Unauthorized);
        }
    }

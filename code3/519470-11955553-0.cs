    public override void OnActionExecuting(HttpActionContext actionContext)
    {
        string methodType = actionContext.Request.Method.Method;
        if (methodType.ToUpper().Equals("POST") 
                || methodType.ToUpper().Equals("PUT"))
        {
             // Your errors
        }
    }

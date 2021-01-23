    public override void OnAuthorization(HttpActionContext actionContext) {
                
        ....
        if (!authorized) {
    
           actionContext.Response =    
                      actionContext.Request.CreateResponse(
                                       HttpStatusCode.Unauthorized, 
                                       new  Dictionary<string, string> { 
                                                    { "hello", "world" } 
                                       }
                      );
                    
        }
            

    [HttpPost(), ModelValidationFilter()]
    public HttpResponseMessage Post(Account account)
    {
        var scope = this.Request.GetDependencyScope();
    
        if(scope != null)
        {
            var accountContext = scope.GetService(typeof(MyContext)) as MyContext;
            accountContext.Accounts.Add(account);
        }
    
        return this.Request.CreateResponse(HttpStatusCode.Created);
    }

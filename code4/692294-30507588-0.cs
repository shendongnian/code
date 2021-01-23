    public override Task OnActionExecutingAsync(HttpActionContext actionContext, CancellationToken cancellationToken)
    {
       if (actionContext.RequestContext.Principal.Identity.IsAuthenticated)
       {
          var userName = actionContext.RequestContext.Principal.Identity.Name;
       }
    }

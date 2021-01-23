    public override void OnActionExecuting(ActionExecutingContext filterContext)
    {    
      var parameters = filterContext.ActionDescriptor.GetParameters();
      if (parameters.Length >= 1)
      {
        var p = parameters[0];
        var val = filterContext.ActionParameters[p.ParameterName];
        Type type = p.ParameterType;
      }
    }

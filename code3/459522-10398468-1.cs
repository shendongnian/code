    private static bool _IsUserAuthorized(HtmlHelper htmlHelper,
      string controllerName, string actionName)
    {
      ControllerContext controllerContext = null;
      //if controllerName is null or empty, we'll use the 
      // current controller in HtmlHelper.ViewContext.
      if (string.IsNullOrEmpty(controllerName))
      {
        controllerContext = htmlHelper.ViewContext.Controller.ControllerContext;
      }
      else //use the controller factory to get the requested controller
      {
        var factory = ControllerBuilder.Current.GetControllerFactory();
        ControllerBase controller = (ControllerBase)factory.CreateController(
          htmlHelper.ViewContext.RequestContext, controllerName);
        controllerContext = new ControllerContext(
          htmlHelper.ViewContext.RequestContext, controller);
      }
      Type controllerType = controllerContext.Controller.GetType();
      ControllerDescriptor controllerDescriptor = new ReflectedControllerDescriptor(controllerType);
      ActionDescriptor actionDescriptor = controllerDescriptor.FindAction(controllerContext, actionName);
      if (actionDescriptor == null)
        return false;
      FilterInfo filters = new FilterInfo(FilterProviders.Providers.GetFilters(
        controllerContext, actionDescriptor));
      AuthorizationContext authContext = new AuthorizationContext(controllerContext, actionDescriptor);
      foreach (IAuthorizationFilter authFilter in filters.AuthorizationFilters)
      {
        authFilter.OnAuthorization(authContext);
        if (authContext.Result != null)
          return false;
      }
      return true;
    }

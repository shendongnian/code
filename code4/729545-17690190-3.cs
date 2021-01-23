    protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
    {
      if (filterContext.HttpContext.Request.IsAjaxRequest())
      {
        filterContext.Result = new JsonResult
        {
          Data = new JsonResponse<bool>
          {
            IsValid = false,
            RedirectTo = FormsAuthentication.LoginUrl
          },
          JsonRequestBehavior = JsonRequestBehavior.AllowGet
        };
      }
      else
      {
        base.HandleUnauthorizedRequest(filterContext);
      }
    }

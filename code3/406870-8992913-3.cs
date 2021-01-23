      public class EnsureHttpAttribute : FilterAttribute, IAuthorizationFilter
      {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
          Verify.NotNull(filterContext, "filterContext");
          Verify.True(filterContext.HttpContext.Request.HttpMethod.Equals("GET", StringComparison.OrdinalIgnoreCase), "filterContext");
    
          var request = filterContext.HttpContext.Request;
          if (request.Url != null && request.IsSecureConnection)
            filterContext.Result = new RedirectResult("http://" + request.Url.Host + request.RawUrl);
        }
      }

      public class EnsureHttpsAttribute : FilterAttribute, IAuthorizationFilter
      {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
          Verify.NotNull(filterContext, "filterContext");
    
          var request = filterContext.HttpContext.Request;
          if (request.Url != null && !request.IsSecureConnection && !request.IsLocal)
            filterContext.Result = new RedirectResult("https://" + request.Url.Host + request.RawUrl);
        }
      }

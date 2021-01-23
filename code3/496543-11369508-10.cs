    public class NoValidationAttribute : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
          // please see the edits in question to see the key generation
          filterContext.HttpContext.Items.Add("NoValidation", true);
        }
    }

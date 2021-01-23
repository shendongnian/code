    public class FeatureAuthenticationAttribute : FilterAttribute, IAuthorizationFilter
    {
        public string AllowFeature { get; set; }
        public void OnAuthorization(AuthorizationContext filterContext)
        {
  
            var filterAttribute = filterContext.ActionDescriptor.GetFilterAttributes(true)
                                    .Where(a => a.GetType() == 
                                   typeof(FeatureAuthenticationAttribute));
            if (filterAttribute != null)
            {
                foreach (FeatureAuthenticationAttribute attr in filterAttribute)
                {
                    AllowFeature = attr.AllowFeature;
                }
           List<Role> roles = 
           ((User)filterContext.HttpContext.Session["CurrentUser"]).Roles;
           bool allowed = SecurityHelper.IsAccessible(AllowFeature, roles);
             if (!allowed)
                {
                    filterContext.Result = new HttpUnauthorizedResult();
                }
            }
        }
    }

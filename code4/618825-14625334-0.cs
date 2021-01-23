    public class IsPostedFromThisSiteAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            //TODO: - Possible problems in future:
            //1. Is there a way to handle the execptions and just display a friendly error page / message.
    
            if (filterContext.HttpContext != null)
            {
                if (filterContext.HttpContext.Request.UrlReferrer == null)
                {
                    var viewResult = new ViewResult
                    {
                        ViewName = "~/Views/Shared/Invalid.cshtml"
                    };
                    filterContext.Result = viewResult;
                    return;
                }
    
                if (filterContext.HttpContext.Request.UrlReferrer.AbsolutePath != ConfigurationManager.AppSettings["SiteURL"])
                {
                    var viewResult = new ViewResult
                    {
                        ViewName = "~/Views/Shared/InvalidSite.cshtml"
                    };
                    filterContext.Result = viewResult;
                    return;
                }
            }
        }
    }

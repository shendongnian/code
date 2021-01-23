    public class WarnAboutOldBrowserAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var request = filterContext.HttpContext.Request;
            //check if it browser warning was already checked
            if (request.Cookies["checked"] != null)
            {
                 return;
            }
            //exmaple is for IE 6
            if (request.Browser.Browser.Trim().ToUpperInvariant().EqualsExact("IE") && request.Browser.MajorVersion <= 6)
            {
              filterContext.Controller.ViewData["RequestedUrl"] = request.Url.ToString();
   
              filterContext.Result = new ViewResult { ViewName = "OldBrowserWarning" };
            }
            //add cookie for caching
            filterContext.HttpContext.Response.AppendCookie(new HttpCookie("checked", "true"));
            }
    
        }
    }

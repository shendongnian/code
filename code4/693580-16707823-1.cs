        public class PopulateTitleDandDateAttribute : ActionFilterAttribute
        {
            public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                var url = filterContext.HttpContext.Request.RawUrl.Split('/');
                if (url.Length >= 7) // TODO: it is actually not good here
                {
                    var d = new DateTime(url[3].ConvertToInteger(), url[4].ConvertToInteger(), url[5].ConvertToInteger());
                    if (filterContext.ActionParameters.ContainsKey("createdDate"))
                    {
                        filterContext.ActionParameters["createdDate"] = d;
                    }
    
                    if (filterContext.ActionParameters.ContainsKey("title"))
                    {
                        filterContext.ActionParameters["title"] = url[6];
                    }
                }
    
                base.OnActionExecuting(filterContext);
            }
        }

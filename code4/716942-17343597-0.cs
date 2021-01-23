    public class SearchAttribute : ActionFilterAttribute
        {
            #region Public Methods and Operators
    
            /// <summary>
            /// Overrides method OnActionExecuting, fires before every controller action is executed. Method retrives list search parameters from current url and saves them in
            /// SearchParams base controller dictionary.
            /// </summary>
            /// <param name="filterContext">
            /// The filter Context.
            /// </param>
            public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                foreach (string key in filterContext.HttpContext.Request.QueryString.AllKeys)
                {
                    if ((key != null) && key.StartsWith("f_"))
                    {
                            filterContext.Controller.ViewData[key] =
                                filterContext.HttpContext.Request.QueryString[key].ToLower();
 
                    }
                }
            }
    
            #endregion
        }

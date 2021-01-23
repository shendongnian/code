    public class CheckForEmptyModelAttribute: ActionFilterAttribute
    {
        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            var viewResult = filterContext.Result as ViewResultBase;
            if (viewResult != null && viewResult.Model == null)
            {
                var view404 = new ViewResult
                {
                    ViewName = "~/Views/Shared/404.cshtml"
                };
                filterContext.Result = view404;
            }
        }
    }

    public class ResultSwitcherAttribute: ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (filterContext.HttpContext.Request["data"] != null && filterContext.HttpContext.Request["data"] == "json")
            {
                filterContext.Result = new JsonResult
                    {
                        Data = (filterContext.Result as ViewResult).Model,
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet
                    };
            }
        }
    }

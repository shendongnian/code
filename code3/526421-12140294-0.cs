    public class ResultSwitcherAttribute: ActionFilterAttribute
    {
          public override OnResultExecuting( filterContext)
          {
                if(filterContext.Request["content"] != null && filterContext.Request["content"] == "json"){
                      filterContext.Result = Json(filterContext.Result)
                 }
          }
    }

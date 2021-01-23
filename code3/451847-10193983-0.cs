    public class AllowOneOffMessagingAttribute : ActionFilterAttribute
    {
        protected override void OnResultExecuting(ResultExecutingContext filterContext)
        {
             base.OnResultExecuting(filterContext);
             var actionResult = filterContext.Result as ViewResult;
             if(actionResult != null)
             {
                  var viewModel = actionResult.ViewData.Model as OneOffMessageViewModelBase;
                  if(viewModel != null)
                  {
                       if(Session["OneOffMessage"] != null)
                       {
                           viewModel.Message = Session["OneOffMessage"];
                           Session["OneOffMessage"] = null;
                       }
                  }
             }
        }
    }

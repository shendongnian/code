    public class PrivateMessageFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutedContext filterContext)
        {
            GlobalViewModel model = null;
            var viewResult = filterContext.Result as ViewResultBase;
            if (viewResult != null)
            {
                // The action returned a ViewResult or PartialViewResult
                // so we could attempt to read the model that was passed
                model = viewResult.Model as GlobalViewModel;
            }
    
            if (model == null)
            {
                var jsonResult = filterContext.Result as JsonResult;
                if (jsonResult != null)
                {
                    // The action returned a JsonResult
                    // so we could attempt to read the model that was passed
                    model = jsonResult.Data as GlobalViewModel;
                }
            }
    
            if (model != null)
            {
                // We've managed to read the model 
                // Now we can set its NewMessages property
                model.NewMessages = GetNewMessages();
            }
        }
    
        private int GetNewMessages()
        {
            int userId = (int)Membership.GetUser().ProviderUserKey;
            int newMessages = db.PrivateMessages.Where(a => a.Receiver.UserId == userId && a.IsRead == false).Count();
        }
    }

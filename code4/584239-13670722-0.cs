    public class PrivateMessageFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutedContext filterContext)
        {
            GlobalViewModel model = null;
            var viewResult = filterContext.Result as ViewResultBase;
            if (viewResult != null)
            {
                model = viewResult.Model as GlobalViewModel;
            }
    
            if (model == null)
            {
                var jsonResult = filterContext.Result as JsonResult;
                if (jsonResult != null)
                {
                    model = jsonResult.Data as GlobalViewModel;
                }
            }
    
            if (model != null)
            {
                model.NewMessages = GetNewMessages();
            }
        }
    
        private int GetNewMessages()
        {
            int userId = (int)Membership.GetUser().ProviderUserKey;
            int newMessages = db.PrivateMessages.Where(a => a.Receiver.UserId == userId && a.IsRead == false).Count();
        }
    }

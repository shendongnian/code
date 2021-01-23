    public class UserInfoInjectorAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var result = filterContext.Result as ViewResultBase;
            if (result == null)
            { 
                // the controller action didn't return any view result => no need to continue
                return;
            }
    
            var model = result.Model as BaseViewModel;
            if (model == null)
            {
                // the controller action didn't pass a model or the model passed to the view
                // doesn't derive from the common base view model that will contain 
                // the user info property => no need to continbue any further
                return;
            }
    
            model.UserInfo = ... go ahead and read the forms authentication cookie
                                 userData portion and extract the information
                                 you are looking for
        }
    }

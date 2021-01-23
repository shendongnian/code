    public class DataAccessAttribute: FilterAttribute, IActionFilter
	{		
		public void OnActionExecuting(ActionExecutingContext filterContext)
		{
			if (filterContext.IsChildAction)
            {
                return;
            }
            var controller = (YourControllerType)filterContext.Controller;
            controller.DocumentSession = Storage.Instance.OpenSession();
		}
		public void OnActionExecuted(ActionExecutedContext filterContext)
		{
			if (filterContext.IsChildAction)
            {
                return;
            }
            var controller = (YourControllerType)filterContext.Controller;
            documentSession = controller.DocumentSession; 
            if (documentSession != null && filterContext.Exception == null)
            {
                documentSession.SaveChanges();
            }
            documentSession.Dispose();
	}

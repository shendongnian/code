    public class DataAccessAttribute: FilterAttribute, IActionFilter
	{		
		public void OnActionExecuting(ActionExecutingContext filterContext)
		{
			if (filterContext.IsChildAction)
            {
                return;
            }
            this.DocumentSession = Storage.Instance.OpenSession();
            base.OnActionExecuting(filterContext);
		}
		public void OnActionExecuted(ActionExecutedContext filterContext)
		{
			if (filterContext.IsChildAction)
            {
                return;
            }
            if (this.DocumentSession != null && filterContext.Exception == null)
            {
                this.DocumentSession.SaveChanges();
            }
            this.DocumentSession.Dispose();
            base.OnActionExecuted(filterContext);
    		}
	}

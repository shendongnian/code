    protected override void OnException(ExceptionContext filterContext) 
    {
        MyLogger.Error(filterContext.Exception);   //method for log in EventViewer
          
        if (filterContext.ExceptionHandled)
            return;
     
        filterContext.HttpContext.Response.StatusCode = (int)System.Net.HttpStatusCode.InternalServerError;
     
        filterContext.Result = new JsonResult
        {
            Data = new
            {
    			Success = false, 
    			Error = "Please report to admin.",
    			ErrorText = filterContext.Exception.Message,
    			Stack = filterContext.Exception.StackTrace
    		},
    		JsonRequestBehavior = JsonRequestBehavior.AllowGet
    	};
    	filterContext.ExceptionHandled = true;
    }

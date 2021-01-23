    public class NotFoundExceptionFilter : IExceptionFilter
    {        
    	public void OnException(ExceptionContext filterContext)
    	{
            // ignore if the exception is already handled or not a 404
    		if (filterContext.ExceptionHandled || new HttpException(null, filterContext.Exception).GetHttpCode() != 404)
    			return;
    
    		filterContext.HttpContext.Items.Add("Programmatic404", true);
    		filterContext.ExceptionHandled = true;
    	}
    }

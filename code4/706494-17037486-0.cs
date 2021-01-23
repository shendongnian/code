     public class ClientErrorHandler : FilterAttribute, IExceptionFilter
     {
        public void OnException(ExceptionContext filterContext)
        {   
           if (filterContext.HttpContext.Request.IsAjaxRequest()) 
           {         
               var response = filterContext.RequestContext.HttpContext.Response;
               response.Write(filterContext.Exception.Message);
               response.ContentType = MediaTypeNames.Text.Plain;
               filterContext.ExceptionHandled = true;
            }
        }
     }

    [MyError]
    public JsonResult Error(string objectToUpdate)
    {
       throw new Exception("ERROR!");
    }
    
    public class MyErrorAttribute : FilterAttribute, IExceptionFilter
    {
       public virtual void OnException(ExceptionContext filterContext)
       {
          if (filterContext == null)
          {
             throw new ArgumentNullException("filterContext");
          }
          if (filterContext.Exception != null)
          {
             filterContext.ExceptionHandled = true;
             filterContext.HttpContext.Response.Clear();
             filterContext.HttpContext.Response.TrySkipIisCustomErrors = true;
             filterContext.HttpContext.Response.StatusCode = (int)System.Net.HttpStatusCode.InternalServerError;
             filterContext.Result = new JsonResult() { Data = filterContext.Exception.Message };
          }
       }
    }

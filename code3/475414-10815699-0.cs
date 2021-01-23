    public void DoSomething()
    {
      // Get the path, which may be null, using the extension method
      var contextPath = HttpContext.Current.RequestPath;
    }
    public static class HttpContextExtensions
    {
      public static string RequestPath(this HttpContext context)
      {
        if (context == null || context.Request == null)
        {
          return default(string);
        }
      
        return context.Request.ApplicationPath;
      }
    }

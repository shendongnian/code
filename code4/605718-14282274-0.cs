    protected override void OnError(EventArgs e)
    {     
      HttpContext ctx = HttpContext.Current;
    
      Exception exception = ctx.Server.GetLastError ();
    
      string errorInfo = 
         "<br>Offending URL: " + ctx.Request.Url.ToString () +
         "<br>Source: " + exception.Source + 
         "<br>Message: " + exception.Message +
         "<br>Stack trace: " + exception.StackTrace;
    
      ctx.Response.Write (errorInfo);
      ctx.Server.ClearError ();
    	
      base.OnError (e);
    }

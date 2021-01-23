    public class MyApplicationContext
    {
        public IPrincipal ContextPrincipal { get; set; }
    
        public MyApplicationContext(HttpContext httpContext)
        {
            // Store the current user principal & identity
            ContextPrincipal = httpContext.User;
            // Need to grab anything else from the HttpContext? Do it here! 
            // That could be cookies, Http request header values, query string 
            // parameters, session state variables, etc.
            //
            // Once you gather up any other stateful data, store it here in 
            // your application context object as the HttpRequest can't be passed 
            // to another thread.
        }
    
    }
    
    public class MyHttpHandler : IHttpHandler
    {
        #region IHttpHandler Members
    
        public bool IsReusable
        {
            // Return false in case your Managed Handler cannot be reused for another request.
            // Usually this would be false in case you have some state information preserved per request.
            get { return true; }
        }
    
        public void ProcessRequest(HttpContext context)
        {
            // Do some work on another thread using the ThreadPool
            ThreadPool.QueueUserWorkItem(new WaitCallback(DoWork), new MyApplicationContext(context));
        }
    
        public void DoWork(object state)
        {
            // Grab our state info which should be an instance of an 
            // MyApplicationContext.
            MyApplicationContext context = (MyApplicationContext) state;
    
            // Assign this ThreadPool thread's current principal according 
            // to our passed in application context.
            Thread.CurrentPrincipal = context.ContextPrincipal;
            // Check if this user is authenticated.
            if (context.ContextPrincipal.Identity.IsAuthenticated)
            {
                var userName = context.ContextPrincipal.Identity.Name;
            }
            // Check if this user is an administrator.
            if (context.ContextPrincipal.IsInRole("Administrator"))
            {
            }
    
            // Do some long-ish process that we need to do on the threadpool 
            // after the HttpRequest has already been responded to earlier.
            //
            // This would normally be some fancy calculation/math, data 
            // operation or file routines.
            for (int i = 0; i < 30; i++)
            {
                Thread.Sleep(1000);
            }
        }
    
        #endregion
    }

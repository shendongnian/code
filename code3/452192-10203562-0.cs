    using System;
    using System.Web;
    using System.Web.Security;
    using System.Web.SessionState;
    using System.Diagnostics;
    
    // This code demonstrates how to make session state available in HttpModule,
    // regradless of requested resource.
    // author: Tomasz Jastrzebski
    
    public class MyHttpModule : IHttpModule
    {
       public void Init(HttpApplication application)
       {
          application.PostAcquireRequestState += new EventHandler(Application_PostAcquireRequestState);
          application.PostMapRequestHandler += new EventHandler(Application_PostMapRequestHandler);
       }
    
       void Application_PostMapRequestHandler(object source, EventArgs e)
       {
          HttpApplication app = (HttpApplication)source;
    
          if (app.Context.Handler is IReadOnlySessionState || app.Context.Handler is IRequiresSessionState) {
             // no need to replace the current handler
             return;
          }
    
          // swap the current handler
          app.Context.Handler = new MyHttpHandler(app.Context.Handler);
       }
    
       void Application_PostAcquireRequestState(object source, EventArgs e)
       {
          HttpApplication app = (HttpApplication)source;
    
          MyHttpHandler resourceHttpHandler = HttpContext.Current.Handler as MyHttpHandler;
    
          if (resourceHttpHandler != null) {
             // set the original handler back
             HttpContext.Current.Handler = resourceHttpHandler.OriginalHandler;
          }
    
          // -> at this point session state should be available
    
          Debug.Assert(app.Session != null, "it did not work :(");
       }
    
       public void Dispose()
       {
    
       }
    
       // a temp handler used to force the SessionStateModule to load session state
       public class MyHttpHandler : IHttpHandler, IRequiresSessionState
       {
          internal readonly IHttpHandler OriginalHandler;
    
          public MyHttpHandler(IHttpHandler originalHandler)
          {
             OriginalHandler = originalHandler;
          }
    
          public void ProcessRequest(HttpContext context)
          {
             // do not worry, ProcessRequest() will not be called, but let's be safe
             throw new InvalidOperationException("MyHttpHandler cannot process requests.");
          }
    
          public bool IsReusable
          {
             // IsReusable must be set to false since class has a member!
             get { return false; }
          }
       }
    }

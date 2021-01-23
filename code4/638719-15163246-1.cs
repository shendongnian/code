    namespace Company.Exceptions
    {
      public class VersionsNotSameHandler: IHttpModule
      {
        public void Dispose() { }
    
        public void Init(HttpApplication application)
        {
            context.PreRequestHandlerExecute += newEventHandler(OnPreRequestHandlerExecute) 
        }
        
        public void OnPreRequestHandlerExecute(Object source, EventArgs e){
      
            HttpApplication app = (HttpApplication)source; 
            HttpRequest request = app.Context.Request;
        // Check for invalid versioning
            app.Response.Redirect('.html page displaying error', true);
        }
      }
    }

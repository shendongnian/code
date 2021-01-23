    public class MyHttpModule : IHttpModule
    {
        void IHttpModule.Dispose() {
        }
        void IHttpModule.Init(HttpApplication context) {
            context.PreRequestHandlerExecute += 
                this.PreRequestHandlerExecute;
        }
        private void PreRequestHandlerExecute(object s, EventArgs e) {
            IHttpHandler handler = 
                this.application.Context.CurrentHandler;
            // CurrentHandler can be null
            if (handler != null) {
                // TODO: Initialization here.
            }            
        }
    }

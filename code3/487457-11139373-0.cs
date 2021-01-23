    public class MyHttpModule : IHttpModule
    {
        public void Init(HttpApplication context)
        {
            context.BeginRequest += new EventHandler(OnBeginRequest);
        }
        protected void OnBeginRequest(object sender, EventArgs e)
        {
            var context = ((HttpApplication) sender).Context;
            // do something here, use the context to get request info
        }
        public void Dispose()
        {
        }
    }

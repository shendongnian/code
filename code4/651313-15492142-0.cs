    public class MyModule : IHttpModule
    {
        public void Init(HttpApplication application)
        {
            application.BeginRequest += this.BeginRequest;
        }
        
        public void BeginRequest(object sender, EventArgs e)
        {
            var app = sender as HttpApplication;
            if (app.Request.Path.Contains("test5.aspx")) {
                return;
            }
            // Process logic for other pages here
        }
    }

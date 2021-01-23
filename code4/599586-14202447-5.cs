public class LoggingModule : System.Web.IHttpModule
{
    private HttpApplication _app;
    public void Dispose() 
    {
        this._app.PreRequestHandlerExecute -= new EventHandler(this.PreRequestExecution);
    }
    public void Init(HttpApplication application)
    {
        this._app = application;
        this._app.PreRequestHandlerExecute += new EventHandler(this.PreRequestExecution);
    }
    private void PreRequestExecution(object sender, EventArgs e)
    {
        var request = this._app.Context.Request;
        var target = request.Form["__EVENTTARGET"];
        var arg = request.Form["__EVENTARGUMENT"];
        //this gives you enough information about events
        //you need to check if they are null before using them (target and arg)
        //through the same request you can get extra info including URL
    }
}

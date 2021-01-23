    public class DefaultHttpApplicationModule
        : System.Web.IHttpModule
    {
       public virtual void Init(HttpApplication context)
        {
            context.EndRequest += context_EndRequest;
        }
       
        void context_EndRequest(object sender, EventArgs e)
        {
            var app = ((HttpApplication)sender);
            var ctx = app.Context;
            string clicked = ctx.Items["button_clicked"] as string;
        }
    }

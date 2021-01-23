    public abstract class BaseControl : System.Web.UI.UserControl
    {
        protected override void OnPreRender(EventArgs e)
        {
            EndFunction();
            base.OnPreRender(e);
        }
        protected override void OnInit(EventArgs e)
        {
            StartFunction();
            base.OnInit(e);
        }
    }

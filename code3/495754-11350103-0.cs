    public class BasePage : System.Web.UI.Page
    {
        public BasePage()
        {
            var myPageLoadDelegate = (EventHandler)Delegate.CreateDelegate(typeof(EventHandler), this, this.GetType().BaseType.Name + "_Load", true, false);
            if (myPageLoadDelegate != null)
            {
                this.Load += myPageLoadDelegate;
            }
        }
    }
    
    public partial class WebForm1 : BasePage
    {
        protected void WebForm1_Load(object sender, EventArgs e)
        {
    
        }
    }

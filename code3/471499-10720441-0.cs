    public class MyPageClass : System.Web.UI.Page
    {
        protected override void OnLoad(EventArgs e)
        {
            // Add your session logic here.
       
            base.OnLoad(e);
        }
    }
    public class WebPage1 : MyPageClass
    {  
        private void Page_Load(object sender, System.EventArgs e)
        {
        }
    }

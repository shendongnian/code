    namespace MyNamespace
    {
        public class Myclass : System.Web.UI.Page
        {
            override protected void OnInit(EventArgs e)
            {
                this.Load += new System.EventHandler(this.Page_Load);
            }
    
            private void Page_Load(object sender, EventArgs e)
            {
            }
        }
    }
    

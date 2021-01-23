    public class Page1 : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ((BasePage)this.Page).MyPopup.DoWhatEver();
        }
    }

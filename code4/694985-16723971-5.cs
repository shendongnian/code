    public partial class OnePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (condition)
            {
                pnlShowA.Visible = true;
                pnlShowB.Visible = false;
            }
            else
            {
                pnlShowA.Visible = false;
                pnlShowB.Visible = true;
            }    
        }
    }

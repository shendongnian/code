    public partial class Page_aspx : System.Web.UI.Page
    {
        protected void RefreshMethod(object sender, EventArgs e)
        {
            this.CallControl1.UpdatePanel.Update();
        }
    }

    public partial class Default : MyPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void btnTest_Click(object sender, EventArgs e)
        {
            try
            {
                System.Web.UI.WebControls.ContentPlaceHolder holder = base.GetMyContentPlaceHolder();
                lblMessage.Text = string.Format("Holder contains {0} control(s).", holder.Controls.Count);
            }
            catch (Exception ex)
            {
                lblMessage.Text = string.Format("Error: {0}", ex.Message);
            }
        }
    }

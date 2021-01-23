    public partial class _Default : System.Web.UI.Page, IPostBackEventHandler
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        public void RaisePostBackEvent(string Arg)
        {
            if (txtG1.ID == Arg)
                txtG1_TextChanged(txtG1, null);
        }
        protected void txtG1_TextChanged(object sender, EventArgs e)
        {
            Label1.Text = System.DateTime.Now.ToString();
        }
    }

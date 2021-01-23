    public partial class UpdatePanelIFrameTester : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void SubmitSponsor(object sender, EventArgs e)
        {
            bool isvalid = true;
            if (isvalid)
            {
                PayPalFrame.Attributes.Add("src", "http://www.ironworks.com");
            }
        }
    }

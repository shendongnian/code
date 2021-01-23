    namespace SO15888490 {
        public partial class page2 : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                litPhoneNumber.Text = (string)Session["PhoneNumber"];
    
                ArrayList al = Session["ItemsList"] as ArrayList;
                if (al != null)
                {
                    foreach (var item in al)
                    {
                        litItemsList.Text += item.ToString() + "<br/>";
                    }
                }
            }
        } }

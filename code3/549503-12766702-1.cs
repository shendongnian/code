    using System;
    using System.Data;
    using System.Configuration;
    using System.Web;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Web.UI.WebControls.WebParts;
    using System.Web.UI.HtmlControls;
    
    
    namespace Test
    {
        public partial class Default : System.Web.UI.Page
        {
            protected void btnAdd_Click(object sender, EventArgs e)
            {
                decimal a = decimal.Parse(txtFirst.Text);
                decimal b = decimal.Parse(txtSecond.Text);
                decimal c = a + b;
                lblAnswer.Text = c.ToString();
            }
        }
    }

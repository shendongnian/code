    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    
    
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
    
        }
    
        protected void btnCalculate_Click(object sender, EventArgs e)
        {
            int plateQty = Convert.ToInt32(txtPlateQty.Text);
            int somethingElse1 = Convert.ToInt32(txtSomethingElse1.Text);
            int somethingElse2 = Convert.ToInt32(txtSomethingElse2.Text);
        }
    }

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    
    public partial class test2 : System.Web.UI.Page
    {
        protected void btnBack_Click(object sender, EventArgs e)
        {
            MultiView2.ActiveViewIndex--;
        }
    
        protected void btnNext_Click(object sender, EventArgs e)
        {
            MultiView2.ActiveViewIndex++;
        }
    
        protected void btnSend_Click(object sender, EventArgs e)
        {
            Response.Write("submitted");
        }
    
    }

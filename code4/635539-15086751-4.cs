    using System;
    using System.Web;
    using System.Web.UI;
    
    public partial class Search : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
    
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            
            Page.ClientScript.RegisterStartupScript(this.GetType(), "CloseScript", "closescript()", true);
    
        }
    }

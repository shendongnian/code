    using System;
    using System.Collections.Generic;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    
    public partial class _Default : System.Web.UI.Page
    {
        public string ServerSideVariable;
    
    
        protected void Page_Load(object sender, EventArgs e)
        {
           string n = String.Format("{0}", Request.Form["cNum"]); //ERROR Here<--- too many character in character literall....
    
            string pval = "Passed value";
            ServerSideVariable = pval;
    
        }
    }

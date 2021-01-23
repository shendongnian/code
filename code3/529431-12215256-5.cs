    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    
    public partial class _Default : System.Web.UI.Page
    {
    
        BAL objBAL;
    
        protected void Page_Load(object sender, EventArgs e)
        {
            Insert();
        }
    
        public void Insert()
        {
            int val = 0;
            objBAL = new BAL();
            objBAL.Name = "stackoverflow";
            try
            {
                val = objBAL.insert();
            }
            catch { }
            finally
            {
                objBAL = null;
            }
            if (val != 0)
            {
                //Insert sucessful
            }
            else
            {
                //Error in Insert.
            }
        }
    }

    using System;
    using System.Web.UI;
    
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UserControl uc = Page.LoadControl("~/UserControl.ascx") as UserControl;
    
            if (uc != null)
            {
                UserControlPlaceHolder.Controls.Add(uc);
            }
        }
    }

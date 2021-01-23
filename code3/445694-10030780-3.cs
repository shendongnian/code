    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    
    public partial class test2 : System.Web.UI.Page
    {
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            //PopulateSomeField();
        }
    
        protected override void OnPreRender(EventArgs e)
        {
            btnBack.Visible = MultiView2.ActiveViewIndex > 0;
            btnNext.Visible = MultiView2.ActiveViewIndex < MultiView2.Views.Count - 1;
            btnSubmit.Visible = MultiView2.ActiveViewIndex == MultiView2.Views.Count - 1;
            base.OnPreRender(e);
        }
    
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

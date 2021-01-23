    using System;    
    using System.Web.UI.HtmlControls;
        
             
      public partial class _Default : System.Web.UI.Page
       {
           protected void Page_Load(object sender, EventArgs e)
           {
              var mycontrol = this.Page.Master.FindControl("yourcontrolname") as HtmlGenericControl;
    
              mycontrol.Attributes.Add("class", "cssToApply");
        
           }
       }
    

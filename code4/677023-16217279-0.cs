    using System;
    
    public partial class TestCheckBox : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "AliveScript", "<script>function CheckAlive(){ return document.getElementById('" + this.AliveChkBox.ClientID + "').checked; } </script>");
    
            this.Submit.OnClientClick = "return CheckAlive();";
        }
        protected void Submit_Click(object sender, EventArgs e)
        {
            
        }
    }

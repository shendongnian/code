    public sealed class MasterPageBase : MasterPage
    {
        protected void AddAlertMessage(string Message)
        {
            var script = String.Format("alert('{0}');", Message);
            this.Page.ClientScript
                .RegisterStartupScript(this.GetType(),"PageAlertMessage",script,true);
        }
    
    }

    using Sytem.Web.SessionState;
    public class YourClass : IRequiresSessionState
    {
        public string MyVar;
        protected void Page_Load(object senser, EventArgs e)
        {
            MyVar = Session["YourSessionVarName"].ToString();
        }
    }

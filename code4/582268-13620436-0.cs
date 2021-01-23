    You can do this using Delegates.
    For Example, you have a button in MasterPage and you want to call a Method in
    Content Page from Master Page.
    Here is the Code in Master Page.
    Master Page:
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (contentCallEvent != null)
                contentCallEvent(this, EventArgs.Empty);
        }
        public event EventHandler contentCallEvent;
    }
    Content Page:
    public partial class Content_1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
    
        }
        private void Master_ButtonClick(object sender, EventArgs e)
        {
            // This Method will be Called.
        }
        protected void Page_PreInit(object sender, EventArgs e)
        {
            // Create an event handler for the master page's contentCallEvent event
            Master.contentCallEvent += new EventHandler(Master_ButtonClick);
        }
    }
    And Also add the Below Line Specifying you MasterPage Path in VirtualPath 
    <%@ MasterType VirtualPath="~/MasterPage.master" %> 
    // This is Strongly Typed Reference

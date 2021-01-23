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

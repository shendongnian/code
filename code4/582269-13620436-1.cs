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

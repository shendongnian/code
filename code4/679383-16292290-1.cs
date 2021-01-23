    public delegate void MessageHandler(string message);
    public partial class SenderUserControl : System.Web.UI.UserControl
    {
        public event MessageHandler SendMessage;
    
        protected void Button1_Click(object sender, EventArgs e)
        {
            SendMessage("test");
        }
    }

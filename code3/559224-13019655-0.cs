    public partial class TextBox : System.Web.UI.UserControl, IUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
    
        }
    
        private string _label;
        public string Label
        {
            get { return _label; }
            set { _label = value; }
        }
    }

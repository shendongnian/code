    public partial class WebUserControl1 : System.Web.UI.UserControl
    {
        private string _Friend;
        public string Friend
        {
            get
            {
                return _Friend;
            }
            set
            {
                _Friend = value;
                lblfriend.Text = value;
            }
        }
        private string _MyName;
        public string MyName
        {
            get
            {
                return _MyName;
            }
            set
            {
                _MyName = value;
                lblmyname.Text = value;
                lblmyname1.Text = value;
            }
        }
      
    }

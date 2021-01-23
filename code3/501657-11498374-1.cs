    public partial class Logon : Form
    {
        public delegate void LoginSuccesful(object sender, LoginEventArgs e);
        public event LoginSuccesful raiseLoginEvent;
        public Logon()
        {
            InitializeComponent();
        }
       
        private void Logon_FormClosing(object sender, FormClosingEventArgs e)
        {
            LoginEventArgs ev = new LoginEventArgs("Admin");
            raiseLoginEvent(this, ev);
        }
    }
    
    public class LoginEventArgs : EventArgs
    {
        public LoginEventArgs(string s)
        {
            loginName = s;
        }
        private string loginName;
        public string Login
        {
            get { return loginName; }
            set { loginName = value; }
        } 
    }

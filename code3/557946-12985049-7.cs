    public partial class UserControl1 : UserControl
    {
       public delegate void LoginOrRegisterHandler(object sender, LoginOrRegisterArgs e);
       public event LoginOrRegisterHandler LoginOrRegisterEvent;
        public UserControl1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            LoginOrRegisterArgs ea = new LoginOrRegisterArgs("logon");
            LoginOrRegisterEvent(sender, ea);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            LoginOrRegisterArgs ea = new LoginOrRegisterArgs("register");
            LoginOrRegisterEvent(sender, ea);
        }
    }
    public class LoginOrRegisterArgs
    {
        public LoginOrRegisterArgs(string s) {Value = s;}
        public string Value {get; private set;}
    }

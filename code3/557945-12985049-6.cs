    public partial class Form1 : Form
    {
        string logonType;
        public Form1()
        {
            InitializeComponent();
        }
        private void userControl1_LoginOrRegisterEvent(object sender, LoginOrRegisterArgs e)
        {
            logonType = e.Value;
            userControl2.BringToFront();
        }
       
        private void userControl2_ControlFinshedEvent(object sender, EventArgs e)
        {
            if (logonType == "logon")
                userControl3.BringToFront();
            else if (logonType == "register")
                userControl4.BringToFront();
        }
        private void userControl3_ControlFinshedEvent(object sender, EventArgs e)
        {
            userControl1.BringToFront();
        }
        private void userControl4_ControlFinshedEvent(object sender, EventArgs e)
        {
            userControl1.BringToFront();
        }
    }

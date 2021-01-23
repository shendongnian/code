    public partial class Form1 : Form
    {
        UserControl1 login = new UserControl1();
        public Form1()
        {
            InitializeComponent();
            login.ExitEvent += new UserControl1.ExitEventHandler(login_ExitEvent);
        }
        void login_ExitEvent(object sender, EventArgs e)
        {
            panel1.Controls.Remove(login);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Controls.Add(login);
            login.BringToFront();
        }
    }

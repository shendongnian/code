    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        private void logOutButton_Click(object sender, EventArgs e)
        {
            //Hide();
            Enabled = false;
            WindowState = FormWindowState.Minimized;
            var f = new LoginForm();
            f.Login += loginShow;
            f.Show();
            f.Activate();
        }
        private void loginShow(object sender, EventArgs args)
        {
            Show();
        }
    }

    public partial class MainForm : Form
    {
        private bool isVerified = false;
        public MainForm()
        {
            InitializeComponent();
            InitializeLogin();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
        }
        private void InitializeLogin()
        {
            if (!isVerified)
            {
                using (LoginForm login = new LoginForm())
                {
                    if (login.ShowDialog() == DialogResult.OK)
                    {
                        MessageBox.Show("Login successful!");
                        isVerified = true;
                    }
                }
            }
            else
            { }
        }

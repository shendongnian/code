       public partial class LoginForm : Form
        {
            public LoginForm()
            {
                InitializeComponent();
            }
    
            public static bool _loginSuccess { get; set; }
            public event EventHandler Login;
            private void loginButton_Click(object sender, EventArgs e)
            {
                if (Program.UserLogin())
                {
                    Close();
                    Dispose();
    
                    if (Application.OpenForms.Count > 0)
                        if (Application.OpenForms["MainForm"].Name == "MainForm")
                        {
                            Application.OpenForms["MainForm"].WindowState = FormWindowState.Normal;
                            Application.OpenForms["MainForm"].Enabled = true;
                        }
                    if (Login != null)
                        Login(this, EventArgs.Empty);
                }
            }
        }

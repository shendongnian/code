    public partial class Form1 : Form
    {
        private DialogResult _loginResult;
        UserClass user = new UserClass();
        public Form1()
        {
            InitializeComponent();
            while (! user.isLoggedIn())
            {
                loginForm login = new loginForm();
                _loginResult = login.ShowDialog();
                if (_loginResult == DialogResult.Cancel)
                {
                    break;
                }
            }
        }
        protected override void OnShown(EventArgs e)
        {
            if (_loginResult == DialogResult.Cancel)
            {
                this.Close(); // which should shut down the app
            }
        }
    }

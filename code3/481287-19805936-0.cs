    public partial class Login : UserControl    {
        public event EventHandler BtnLoginClick;
        public Login()
        {
            InitializeComponent();
        }
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string userName = txtUserName.Text;
            string userPassword = txtUserPassword.Password.Trim();
            if (userName != null && userName != string.Empty && userPassword != null &&       userPassword != string.Empty)
            {
                if (this.BtnLoginClick != null)
                {
                    this.BtnLoginClick(this, e);
                }
            }
            else
            {
                MessageBox.Show("Invalid username or password");
            }
        }

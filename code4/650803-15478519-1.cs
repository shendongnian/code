    public partial class Control_Center: Form
    {
        public Control_Center()
        {
            InitializeComponent();
        }
        private void Control_Center_Load(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            var authorizationResult = loginForm .ShowDialog();
            if (authorizationResult  != System.Windows.Forms.DialogResult.OK)
            {
                this.Close();
            }
        }
    }

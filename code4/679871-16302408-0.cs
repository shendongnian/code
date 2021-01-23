    public partial class Form1 : Form
    {
        UserClass user = new UserClass();
        public Form1()
        {
            InitializeComponent();
            while (! user.isLoggedIn())
            {
                loginForm login = new loginForm();
                var result = login.ShowDialog();
                if (result == DialogResult.Cancel) { break; }
            }
        }
    }

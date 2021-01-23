    //Progrmm.cs
    Application.Run(new Form1());
    //LoginForm.cs
    public partial class LoginForm : Form
    {
        public LoginForm ()
        {
            InitializeComponent();
        }
        private void buttonLogin_Click(object sender, EventArgs e)
        {
            //check username password
            if(texboxUser == "user" && texboxPassword == "password")
            {
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Wrong user pass");
            }
        }
    }

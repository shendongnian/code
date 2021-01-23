       public partial class MainForm : Form
        {
            public Form1()
            {
                InitializeComponent();
                DialogResult dr = new DialogResult ();
                LoginForm loginForm = new LoginForm ();
                dr = loginForm.ShowDialog();
                if ( dr == DialogResult.OK )
                {
                   //user is authenticated
                }
                else 
                {
                   //user isn't
                }
            }
        }

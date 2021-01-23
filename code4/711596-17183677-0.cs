    public class frmCredentials : Form
    {
        public frmCredentials()
        {
            InitializeComponent();
        }
    
        public frmCredentials(string myValue )
        {
            InitializeComponent();
            txtUsername.Text = myValue;
        }
    }

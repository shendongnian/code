    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (IsUser())
            {
                // the DialogResult of the Form must be set 
                this.DialogResult = System.Windows.Forms.DialogResult.OK;    
            }
        }
        private bool IsUser()
        {
            return true;
        }

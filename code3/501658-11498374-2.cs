    public partial class PasswordChange : Form
    {
        public PasswordChange()
        {
            InitializeComponent();
        }
        public string LoginName
        {
            get {return  textBox1.Text; }
            set { textBox1.Text = value; }
        }
    }

    public partial class Form1 : Form
    {
        ErrorProvider errorProvider = new ErrorProvider();
        public Form1()
        {
            InitializeComponent();
            textBox1.Validating += new CancelEventHandler(textBox1_Validating);
        }
        private void textBox1_Leave(object sender, EventArgs e)
        {
            textBox1.CausesValidation = true;
        }
        void textBox1_Validating(object sender, CancelEventArgs e)
        {
            Regex UserNameRE = new Regex(@"^[a-zA-Z]\w*$");
            if (!UserNameRE.IsMatch(textBox1.Text))
            {
                errorProvider.SetError(this.textBox1, "Invalid username");
            }
        }
    }

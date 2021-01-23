        public partial class Transaction : Form
        {
            Form1 _mainForm;
            public Transaction(Form1 mainForm)
            {
                InitializeComponent();
                _mainForm = mainForm;
            }
            private void button4_Click(object sender, EventArgs e)
            {
                this.Close();  //since you always create a new one in Form1
                _mainForm.Show();
            }
        }

    public partial class Form1 : Form
    {
        Form MyForm;
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (MyForm != null)
                MyForm.Dispose();
            MyForm = new Form() { Text = DateTime.Now.ToString() };
            MyForm.Show();
        }
    }        

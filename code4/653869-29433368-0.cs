    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            Form1 NewForm = new Form1();           
            NewForm.Show();
            this.Dispose(false);
        }
    }

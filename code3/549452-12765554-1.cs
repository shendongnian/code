        public partial class frmInput : Form
        {
            public frmInput()
            {
                InitializeComponent();
            }
            private void button1_Click(object sender, EventArgs e)
            {
                //update user input to customer list in parent form
                Form1.lsvCustomer.Items.Add(textBox1.Text);
            }
        }

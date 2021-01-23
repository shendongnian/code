     public partial class Form2 : Form
        {
            public string textData;
            public Form2()
            {
                InitializeComponent();
            }
    
            private void btnOK_Click(object sender, EventArgs e)
            {
                textData = textBox1.Text + " " + textBox2.Text;
                this.Close();
            }
    
            private void btnCancel_Click(object sender, EventArgs e)
            {
                this.Close();
            }
        }

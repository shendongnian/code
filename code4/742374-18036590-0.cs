    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }        
        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox1.Focus();
            }
        }
        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (textBox3.Text == "")
            {
                textBox2.Focus();
            }
        }                  
    }

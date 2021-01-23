    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            textBox1.Text = myProperties.sti;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            myProperties.sti  = textBox1.Text;
            this.Close();
        }
    }

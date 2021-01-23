    public partial class Form1 : Form
    {
        int i;
        public Form1()
        {
            InitializeComponent();
            i = 0;
        }
   
        //...
        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = (++i).ToString();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = (--i).ToString;
        }
    }

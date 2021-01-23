    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Focus();
            SendKeys.SendWait("^{LEFT}");
        }
        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Focus();
            SendKeys.SendWait("^{RIGHT}");
        }
    }

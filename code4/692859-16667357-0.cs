    public partial class Form1 : Form
    {
        private const string GOODBYE = "Goodbye Cruel World";
        private const string HELLO = "Hello World!";
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals(GOODBYE ))
            {
                textBox1.Text = HELLO;
            }
            else { textBox1.Text = (GOODBYE ); }
        }
    }

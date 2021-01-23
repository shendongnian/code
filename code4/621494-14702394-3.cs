    namespace WindowsFormsApplication2
    {
    public partial class Form1 : Form
    {
        Form2 f2 = new Form2();
        
        public Form1()
        {
            InitializeComponent();
            f2.Show();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            f2.button1.Size = new Size(int.Parse(textBox1.Text), int.Parse(textBox2.Text));
        }
    }
    }

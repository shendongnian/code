    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        { 
             string a = textBox1.Text;
             Form2.ShowMeaning(a);// it will be called as many time as you click
        }
    }

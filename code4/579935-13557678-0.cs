    public partial class Form1 : Form
    {
        Form2 frm2;
        public Form1()
        {
            InitializeComponent();
            frm2 = new Form2();
            frm2.Show(this);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            frm2.ModifyTextBoxValue = textBox1.Text;
        }
    }

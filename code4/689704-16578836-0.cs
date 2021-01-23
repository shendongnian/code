    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form3 frm3 = new Form3();
            frm3.Show(this);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2(); //Show Form2 for Testing
            frm2.Show();
        }
    }

    public partial class Form1 : Form
    {
        Form2 frm2 = new Form2();
        public Form1()
        {
            InitializeComponent();
            frm2.Show();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            frm2.setTopMost = !frm2.setTopMost;
            this.BringToFront();
        }
    }

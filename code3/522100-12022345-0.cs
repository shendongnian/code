    public partial class Form2 : Form
    {
        public String sti { get; set; }
        public Form2()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form3 frm = new Form3();
            frm.ShowDialog();
            sti = frm.sti;
            textBox1.Text = sti;
        }
    }

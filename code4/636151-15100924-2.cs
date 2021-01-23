    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var frm2 = new Form2(dataGridView1.Rows[0].Cells[0].Value.ToString());
            frm2.Show();
        }
    }

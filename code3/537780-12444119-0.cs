    public partial class Form1 : Form
    {
        Form2 frm2;
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            frm2 = new Form2();
            DialogResult dr = frm2.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                frm2.Close();
            }
            else if (dr == DialogResult.OK)
            {
                textBox1.Text = frm2.getText();
                frm2.Close();
            }
        }
    }

    public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                this.IsMdiContainer = true;
            }
            List<string> list = new List<string> { "a", "b", "c" };
            private void button1_Click(object sender, EventArgs e)
            {
                Form2 frm2 = new Form2(list);
                frm2.MdiParent = this;
                frm2.Show();
            }
            private void Form1_Load(object sender, EventArgs e)
            {
                comboBox1.DataSource = list;
            }
        }
    }

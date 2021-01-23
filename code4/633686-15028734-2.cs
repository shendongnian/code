    public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                Form2 frm2 = new Form2();
                frm2.Show();
                frm2.FormClosing += new FormClosingEventHandler(frm2_FormClosing);
            }
    
            void frm2_FormClosing(object sender, FormClosingEventArgs e)
            {
                if ((sender as Form2).textData != null)
                    textBox1.Text = (sender as Form2).textData;
            }
        }

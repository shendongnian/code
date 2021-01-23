     public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                Form2 frm2 = new Form2();
                frm2.FormClosing += frm2_FormClosing;
                frm2.Show();
            }
    
            void frm2_FormClosing(object sender, FormClosingEventArgs e)
            {
                MessageBox.Show("form 2 closed");
            }
        }

    public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                this.Close();
                Form2 form = new Form2();
                form.Show();
            }
        }

    public partial class Form1 : Form
        {
            Form2 f2;
            public Form1(Form2 f)
            {
                InitializeComponent();
                f2 = f;
                f2.Show();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                f2.enableB();
            }
        }

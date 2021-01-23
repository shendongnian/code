    public partial class Form1 : Form
    {
        UserControl1 usr1 = new UserControl1();
        UserControl2 usr2 = new UserControl2();
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            panel1.Controls.Add(usr1 );
        }
        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            panel1.Controls.Add(usr2 );
        }
    }

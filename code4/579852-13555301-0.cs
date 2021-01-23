    public partial class Form1 : Form
    {
        UserControl1 usr;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Shown(object sender, EventArgs e)
        {
            usr = new UserControl1();
            usr.Dock = DockStyle.Fill;
            panel1.Controls.Add(usr);
        }
    }

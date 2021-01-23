    public partial class Form1 : Form
    {
        UserControl1 login = new UserControl1();
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Controls.Add(login);
            login.BringToFront();
        }
    }

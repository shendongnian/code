    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }
        public void FrmMain_MouseMove(object sender, MouseEventArgs e)
        {
            this.label1.Text = DateTime.Now.ToString();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            new Form1().Show();
        }
    }

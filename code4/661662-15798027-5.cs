    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        protected void button1_Click(object sender, EventArgs e)
        {
            Form1.Instance.PrintCtrl1.Text = "";
        }
    }

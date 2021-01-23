    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void TestClick()
        {
            button2.PerformClick();
        }
        private void btn_add_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You Clicked it");
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            TestClick();
        }
    }

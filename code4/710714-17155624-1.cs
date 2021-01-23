    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //Do not call methods on controls here, the controls are not yet initialized
        }
        private void TestClick()
        {
            btn_add.PerformClick();
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

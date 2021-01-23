    public partial class Form1 : Form
    {
        UserControl1 uc1 = new UserControl1();
        public Form1()
        {
            InitializeComponent();
            
            **Controls.Add(uc1);**
        }
        private void button1_Click(object sender, EventArgs e)
        {
            uc1.MinimMaxim();
            // userControl11.MinimMaxim();
        }
    }
}

    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();   
        }
        private void button1_Click(object sender, EventArgs e)
        {
            // call MouseMove event in main form
            Program.MainForm.FrmMain_MouseMove(null, null);
        }
    }

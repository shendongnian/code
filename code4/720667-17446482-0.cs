    public partial class Form1 : Form
    {
        bool flag = false;
        public Form1()
        {
            InitializeComponent();
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (flag)
            {
                //save settings 
            }
        }
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (flag)
            {
                //save settings 
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            checkBox1.Checked = Properties.Settings.Default.check1_State;
            checkBox2.Checked = Properties.Settings.Default.check2_State;
            flag = true;
        }
    }

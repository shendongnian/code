    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            radioButton1.Checked = true;
            radioButton3.Checked = true;
            radioButton2.CheckedChanged += radioButton2_CheckedChanged;
        }
        void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            groupBox2.Enabled = !radioButton2.Checked;
        }
    }

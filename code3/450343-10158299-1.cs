    public partial class Form3 : Form
    {
        string[] textValues = new string[6];
        public Form3()
        {
            InitializeComponent();
        }
        public string[] getTextBoxValues()
        {
            return textValues;
        }
        private void saveSettings_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
            textValues[0] = textBox1.Text;
            textValues[1] = textBox2.Text;
            textValues[2] = textBox3.Text;
            textValues[3] = textBox4.Text;
            textValues[4] = textBox5.Text;
            textValues[5] = textBox6.Text;
            this.Close();
        }
        private void cancelSettings_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
    }

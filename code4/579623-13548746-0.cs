    public partial class Form1 : Form
    {
        string[] values;
        public Form1()
        {
            InitializeComponent();
            values = setValueArray();
            numericUpDown1.Maximum = values.Length - 1;
            numericUpDown1.Minimum = 0;
        }
        private string[] setValueArray()
        {
         return new string[] { "100", "90", "80", "70", "60" };
        }
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            label1.Text = values[(int)((NumericUpDown)sender).Value];
        }
    }

    namespace WindowsFormsApplication2
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void numericUpDown1_ValueChanged(object sender, EventArgs e)
            {
                if (numericUpDown1.Value > 5)
                    button1.Enabled = false;
            }
        }
    }

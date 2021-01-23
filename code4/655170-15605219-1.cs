    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public Form1 FormOne { get; set; }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (FormOne == null)
            {
                return;
            }
            FormOne.SetLabelText("some text");
        }
    }

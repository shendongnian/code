    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form2 childForm = new Form2();
            childForm.ShowDialog();
            string name = childForm.Name;
            string value = childForm.SomeOtherValue;
            //you can stick these properties in your dataset here.
        }
    }
    
    public partial class Form2 : Form
    {
        private TextBox textbox1;
        public Form2()
        {
            InitializeComponent();
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    
        public string Name { get { return textbox1.Text; } }
        public string SomeOtherValue { get { return "12345"; } }
    }

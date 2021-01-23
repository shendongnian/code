    public partial class Form2 : Form
    {
        Form1 form1;
        public Form2()
        {
            InitializeComponent();
        }
    
        public Form2(Form1 parentForm)
        {
            InitializeComponent();
            this.form1 = parentForm;
        }
    
        private void button2_Click(object sender, EventArgs e)
        {
            foreach(string item in form1.GetCheckedItems())
            {
                listBox1.Items.Add(item);
            }
        }
    }

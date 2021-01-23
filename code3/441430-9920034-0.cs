    public partial class Form1 : Form
    {
        public string MyProperty { get; set; }
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            MyProperty = "Some complex result";
        }
        private void button2_Click(object sender, EventArgs e)
        {
            MyProperty = "Some other complex result";
        }
    }

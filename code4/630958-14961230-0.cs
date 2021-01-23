    public partial class Form1 : Form
    {
        private string _data;
    
        public Form1()
        {
            InitializeComponent();
            _data = "Some data";
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
            var form2 = new Form2();
            form2.Data = _data;
            form2.Show();
        }
    }
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
    
        public string Data { get; set; }
    }

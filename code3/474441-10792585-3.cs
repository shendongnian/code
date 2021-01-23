    public partial class Form2 : Form
    {
        public string name { get; set; }
        public string age { get; set; }
        public Form2()
        {
            InitializeComponent();
        }
        
        private void Form2_Load(object sender, EventArgs e)
        {
            textBox1.Text = name;
            textBox2.Text = age;
        }
    }

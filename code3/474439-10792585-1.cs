    public partial class Form2 : Form
    {
        public string Name { get; set; }
        public string Age { get; set; }
        public Form2()
        {
            InitializeComponent();
        }
        
        private void Form2_Load(object sender, EventArgs e)
        {
            textBox1.Text = Name;
            textBox2.Text = Age;
        }
    }

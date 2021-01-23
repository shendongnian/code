    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            List<string> list = new List<string> { "a", "b", "c" };
            comboBox1.DataSource = list;
            Form1.list = list;
    
        }
    }
    

    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        List<string> list = new List<string> { "a", "b", "c" };
        private void Form2_Load(object sender, EventArgs e)
        {            
            comboBox1.DataSource = list;
            Form1.list = list;
    
        }
    }
    

    public partial class Form1 : Form
    {
        List<string> list = new List<string> { 
            "just", "putting", "something", "inside", "the", "list"
        };    
    
        public Form1()
        {
            InitializeComponent();
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
            List.Add("gdgd");
        }
    
        public List<string> List
        {
            get { return list; }
            set { list = value; }
        }
    }

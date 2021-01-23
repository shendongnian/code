    public partial class Form1 : Form
    {
        public List<string> List { get; set; }
    
        public Form1()
        {
            InitializeComponent();
            List = new List<string> { 
                "just", "putting", "something", "inside", "the", "list"
            };    
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
            List.Add("gdgd");
        }
    }

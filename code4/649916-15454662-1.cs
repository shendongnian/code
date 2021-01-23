    public partial class addChannel : Form
    {                     
        private TreeView _treeView; // TreeView on other Form.
        public addChannel(TreeView treeView)
        {
            InitializeComponent();
            _treeView = treeView;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            // Save the info to an XML doc
            // Access _treeView here
            Console.WriteLine(_treeView.Name);
            this.Close();
        }
    }

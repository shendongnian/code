    public partial class Form1 : Form
    {
        RadTreeView tree = new RadTreeView();
        public Form1()
        {
            InitializeComponent();
            this.Controls.Add(tree);
            tree.Size = new Size(500, 500);
            tree.AllowEdit = true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            RadTreeNode newNode = new RadTreeNode();
            newNode.Text = "new Cabinet";
            tree.Nodes.Add(newNode);
            newNode.BeginEdit();
        }
    }

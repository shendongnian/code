    public partial class Form1 : Form
    {
        string clickedNode;
        MenuItem myMenuItem = new MenuItem("Show Me");
        ContextMenu mnu = new ContextMenu();
        public Form1()
        {
            InitializeComponent();
            mnu.MenuItems.Add(myMenuItem);
            myMenuItem.Click += new EventHandler(myMenuItem_Click);
        }
        void myMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new Form();
            frm.Text = clickedNode;
            frm.ShowDialog(this);
            clickedNode = "";
        }
        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                clickedNode = e.Node.Name;
                mnu.Show(treeView1,e.Location);
            }
        }
    }

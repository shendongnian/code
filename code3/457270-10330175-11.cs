        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateTree();
            }
        }
        private void PopulateTree()
        {
            sampleTree.Nodes.Clear();
            CustomTreeNode root = new CustomTreeNode();
            root.Value = "root node";
            sampleTree.Nodes.Add(root);
            // Creating some fake nodes (you would of course be using real data)
            for (int i = 0; i < 10; i++)
            {
                CustomTreeNode child = new CustomTreeNode();
                child.NodeId = i;               // Saved in ViewState
                child.NodeType = "Type " + i;   // Saved in ViewState
                child.Value = child.NodeType;
                root.ChildNodes.Add(child);
            }
        }
        protected void sampleTree_SelectedNodeChanged(object sender, EventArgs e)
        {
            CustomTreeView cTreeView = (CustomTreeView) sender;
            lblSelectedNode.Text = ((CustomTreeNode)cTreeView.SelectedNode).NodeType;
        }

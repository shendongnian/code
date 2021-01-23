        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }
        private void BindData()
        {
            sampleTree.Nodes.Clear();
            CustomTreeNode root = new CustomTreeNode();
            root.NodeType = "root node";
            sampleTree.Nodes.Add(root);
            // Creating some fake nodes (you would of course be using real data)
            for (int i = 0; i < 10; i++)
            {
                CustomTreeNode child = new CustomTreeNode();
                child.NodeId = i;
                child.NodeType = "Type " + i;
                child.Value = child.NodeType;
                root.ChildNodes.Add(child);
            }
        }
        protected void sampleTree_SelectedNodeChanged(object sender, EventArgs e)
        {
            CustomTreeView cTreeView = (CustomTreeView) sender;
            lblSelectedNode.Text = ((CustomTreeNode)cTreeView.SelectedNode).NodeType;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            processNode(trvTest.Nodes);
        }
        private void processNode(TreeNodeCollection nodes)
        {
            foreach (TreeNode node in nodes)
            {
                node.SelectAction = TreeNodeSelectAction.None;
                if (node.ChildNodes.Count > 0)
                    processNode(node.ChildNodes);
            }
        }

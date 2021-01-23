    protected void testtree1_SelectedNodeChanged(object sender, EventArgs e)
    {
        var selectedNode = (sender as System.Web.UI.WebControls.TreeView).SelectedNode;
        selectedNode.ChildNodes.Add(new TreeNode('Your TreeNode here'));
    }

        TreeNode yourGlobalTreeNode;
        void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            yourGlobalTreeNode = e.Node;
            otherFunction();
            anOtherFunction(e.Node);
        }
        void otherFunction()
        {
            MessageBox.Show(yourGlobalTreeNode.Text);
        }
        void anOtherFunction(TreeNode tn)
        {
            MessageBox.Show(tn.Text);
        }
    

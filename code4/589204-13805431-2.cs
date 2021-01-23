       private void treeView_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            TreeNode NewNode;
        
            if(e.Data.GetDataPresent("System.Windows.Forms.TreeNode", false))
            {
                NewNode = (TreeNode)e.Data.GetData("System.Windows.Forms.TreeNode");
                if (!(sender as TreeView).Nodes.Contains(NewNode))//Edit: add this if you don't want to add the same one again.
                {    
                     (sender as TreeView).Nodes.Add((TreeNode) NewNode.Clone());                 
                     NewNode.Remove(); //Edit: add this if you want to remove original one.
                } 
            }
        }

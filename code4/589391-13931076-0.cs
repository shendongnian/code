    private void treeView_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
    {
        TreeNode NewNode;
    
        if (e.Data.GetDataPresent("System.Windows.Forms.TreeNode", false))
        {
            NewNode = (TreeNode)e.Data.GetData("System.Windows.Forms.TreeNode");
            if (!(sender as TreeView).Nodes.Contains(NewNode))
            {
                //Add the droped node 
                List<TreeNode> tt = new List<TreeNode>();
                TreeNode tn = (TreeNode)NewNode.Clone();
                tt.Add(tn);
    
                //Prepare node with it's parents until the root note
                while ((TreeNode)NewNode.Parent is TreeNode)
                {
                    TreeNode tnp = (TreeNode)NewNode.Parent.Clone();
    
                    //prevent siblings to be added
                    tnp.Nodes.Clear();
    
                    tt.Add(tnp);
                    NewNode = NewNode.Parent;
                }
    
                //Construct the structure of the treenote to be added to the treeview
                for (int i = tt.Count - 1; i > 0; i--)
                {
                    tt[i].Nodes.Add(tt[i - 1]);
                }
    
                /*Add the whole structured treenode to the treeview*/
    
    
                TreeNode rootnote = ExistNotes((sender as TreeView), tt[tt.Count - 1]);
                if (rootnote != null)//Root node exists, add to the existing node
                {
                    foreach (TreeNode tsub in tt[tt.Count - 1].Nodes)
                    {
                        addNotes(rootnote, tsub);
                    }
                }
                else//Root node not exist, add to the treeview as new node.
                {
                    (sender as TreeView).Nodes.Add(tt[tt.Count - 1]);
                }
    
                //  NewNode.Remove();
            }
        }
    }
    

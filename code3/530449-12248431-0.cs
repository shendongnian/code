        private TreeNode selectedNodeA;
        private TreeNode selectedNodeB;
        private void treeViewA_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //Reset color if was perviously highlighted
            if (selectedNodeA != null)
                selectedNodeA.BackColor = Color.White;
            selectedNodeA = e.Node;
            //Here you can indicate the node is selected, change background color or set font to
            // Bold or any other tricks!
            selectedNodeA.BackColor = Color.LightGray;
             //Rest of code
         }

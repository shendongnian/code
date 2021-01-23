            List<string> mylist = market.Trim('~').Split(new string[] { @"\" }, StringSplitOptions.RemoveEmptyEntries).ToList();
            if (mylist.Count > 0)
            {
                TreeNode root = new TreeNode(mylist[0]);
                treeView1.Nodes.Add(root);
                mylist.RemoveAt(0);
                TreeNode temp = root;
                foreach (string s in mylist)
                {
                    temp = AddNode(temp, s);
                }
                treeView1.SelectedNode = root;
            }

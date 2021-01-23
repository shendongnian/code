       ...
            string path = @"A\1\2\";
            var path_list = path.Split('\\').ToList();
            foreach (TreeNode node in treeView1.Nodes)
                if (node.Text == path_list[0])
                    ExpandMyLitleBoys(node, path_list);
        }
        private void ExpandMyLitleBoys(TreeNode node, List<string> path)
        {
            path.RemoveAt(0);
            node.Expand();
            if (path.Count == 0)
                return;
            foreach (TreeNode mynode in node.Nodes)
                if (mynode.Text == path[0])
                    ExpandMyLitleBoys(mynode, path); //recursive call
            
        }

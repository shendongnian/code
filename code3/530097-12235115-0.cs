     TreeNode[] n = treeView1.Nodes.Find(search, true);
                if (n.Length > 0)
                    found = true;
                treeView1.Nodes[t].Collapse();
                foreach (TreeNode p in n)
                {
                    i = 0;
                    string[] a = p.FullPath.Split('\\');
                    foreach (string b in a)
                    {
                       
                        if (i == 0)
                        {
                            treeView1.SelectedNode = treeView1.Nodes[b];
                            current = treeView1.Nodes[b];
                            treeView1.SelectedNode.Expand();
                            i = 1;
                        }
                        else
                        {
                            treeView1.SelectedNode = current.Nodes[b];
                            current = current.Nodes[b];
                            treeView1.SelectedNode.Expand();
                            if (b.ToUpper().Contains(search))
                            {
                                treeView1.SelectedNode.BackColor = System.Drawing.Color.Red;
                            }

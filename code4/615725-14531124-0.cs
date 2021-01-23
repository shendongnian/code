    TreeNodeCollection nodes = this.treeView1.Nodes;
            foreach (TreeNode n in nodes)
            {
                foreach (TreeNode c in n.Nodes)
                {
                    if (c.Checked)
                    {
                        c.BackColor = Color.Gray;
                    }
                }
                if (n.Checked)
                {
                    n.BackColor = Color.Black;
                }
            }

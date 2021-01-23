    private void Form1_Load(object sender, EventArgs e)
    {
        treeView1.CheckBoxes = true;
        treeView1.BeginUpdate();
        treeView1.Nodes.Add("1111");
        treeView1.Nodes[0].Nodes.Add("2222");
        treeView1.Nodes[0].Nodes.Add("2222");
        treeView1.Nodes[0].Nodes.Add("2222");
        treeView1.Nodes[0].Nodes.Add("2222");
        treeView1.Nodes[0].Nodes[1].Nodes.Add("3333");
        treeView1.Nodes[0].Nodes[1].Nodes[0].Nodes.Add("4444");
        treeView1.Nodes[0].Nodes[1].Nodes[0].Nodes.Add("4444");
        treeView1.Nodes[0].Nodes[1].Nodes[0].Nodes.Add("4444");
        treeView1.EndUpdate();
        treeView1.ExpandAll();
    }
    private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
    {
        foreach (TreeNode childNode in e.Node.Nodes)
        {
            childNode.Checked = e.Node.Checked;
        }
    }

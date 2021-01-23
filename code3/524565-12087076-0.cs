    void treeView1_BeforeSelect(object sender, TreeViewCancelEventArgs e)
    {
        e.Node.Tag = (int)(e.Node.Tag ?? 0) + 1;
        int count = (int)(e.Node.Tag); 
        e.Node.Text = String.Format("selected {0} Count: {1}", e.Action.ToString(), count);
     }

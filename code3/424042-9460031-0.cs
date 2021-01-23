    System.Windows.Forms.TreeView tv;
    void tv_AfterLabelEdit(object sender, System.Windows.Forms.NodeLabelEditEventArgs e)
    {
        tv.SelectedNode = e.Node;
        tv.Focus();
    }

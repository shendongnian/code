    private void treeViewProduct_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (insertMode)
            {
                treeViewProduct.NotifyAboutInsert(e.Node.Index);
            }
    ...
    }

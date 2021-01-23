    private void customTreeViewSql_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
    {
        // Ensure selected node is selected.
        treeView.BeginUpdate();
        this.SqlTreeView.SelectedNode = e.Node;
        try
        {
            if (e.Node.Level == 0)
            {
                if (e.Button == MouseButtons.Right)
                    contextMenuStripA.Show(MousePosition);
            }
            else if (e.Node.Level == 1)
            {
                if (e.Button == MouseButtons.Right)
                    contextMenuStripB.Show(MousePosition);
            }
        }
        finally
        {
            treeView.EndUpdate();
        }
    }

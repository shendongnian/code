    const string[] suffix = { "B", "KB", "MB", "GB", "TB" };
    private void btnAddToListViewCheckedItem_Click(object sender, EventArgs e)
    {
        try
        {
            lvLoadSelectedFileAndFolder.BeginUpdate();
            foreach (TreeNode tn in tvLoadTreeviewFromListView.Nodes)
            {
                AddToListView(tn);
            }
        }
        finally
        {
            lvLoadSelectedFileAndFolder.EndUpdate();
        }
    }

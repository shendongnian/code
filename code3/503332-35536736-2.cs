    private void CompareTreeViewItem(TreeViewItem TViewItem1,TreeViewItemTViewItem2)
    {
        if ((string)TViewItem1.Header == (string)TViewItem2.Header)
        {
            TViewItem2.IsExpanded = TViewItem1.IsExpanded;
            if (TViewItem1.Items.Count > 0)
            {
                for (int i = 0; i < TViewItem1.Items.Count && i < TViewItem2.Items.Count; i++)
                {
                    CompareTreeViewItem((TreeViewItem)TViewItem1.Items[i],
                                        (TreeViewItem)TViewItem2.Items[i]);
                }
            }
        }
    }

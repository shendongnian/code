    private void SetItemHeader(ItemCollection treeViewItems, string input, string output)
    {
        for (int index = 0; index < treeViewItems.Count; index++)
        {
            TreeViewItem item = (TreeViewItem)treeViewItems[index];
            if (item.Header == input)
            {
                item.Header = output;
                return;
            }
            else if (item.Items.Count > 1) SetItemHeader(item.Items, input, output);
        }
    }

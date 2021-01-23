    void DeleteIfNecessary(string message)
    {
        ListViewItem listViewItem = FindListViewItemForMessage(s);
        if (listViewItem == null)
        {
            // item doesn't exist
            return;
        }
    
        this.listView1.Items.Remove(listViewItem);
    }
    
    private ListViewItem FindListViewItemForMessage(string s)
    {
        foreach (ListViewItem lvi in this.listView1.Items)
        {
            if (StringComparer.OrdinalIgnoreCase.Compare(lvi.Text, s) == 0)
            {
                return lvi;
            }
        }
    
        return null;
    }

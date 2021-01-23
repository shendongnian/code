    private void Item_MouseDoubleClick(object sender, MouseEventArgs e)
    {
        if ((sender as TreeViewItem).Parent is TreeViewItem)
        {
           // This is a child
        }
        else
        {
           // This is a root element
        }
    }

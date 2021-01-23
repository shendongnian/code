    private void OnContextMenuItem_Clicked(object sender, ToolStripMenuItemClickedEventArgs e)
    {
        ToolStripItem clickedItem = e.ClickedItem;
        string itemName = clickedItem.Text;
        ...
    }

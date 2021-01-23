    cm.MenuItems.Add("Item 2", HandleContextMenuClick);
    
    private void HandleContextMenuClick(object sender, EventArgs e)
    {
      if (...) ReadDocument();
    }

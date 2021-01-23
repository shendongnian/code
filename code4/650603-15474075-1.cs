    List<Int32> lstindex = new List<Int32>();
    String[] splt = txtSelect.Text.Split(',');
    
    // initialize list of indexed for textbox
    foreach (String str in splt)
    {
        lstindex.Add(Convert.ToInt32(str) - 1);
    }
    
    // for each menu
    foreach (ToolStripMenuItem mnItem in msMenus.Items)
    {
         // for each menu item
        foreach (ToolStripItem item in mnItem.DropDown.Items)
        {
            // if index of item is in the list of indexed, set visible to false, otherwise to true
            item.Visible = lstindex.Contains(mnItem.DropDown.Items.IndexOf(item)) ? false : true;
        }
    }

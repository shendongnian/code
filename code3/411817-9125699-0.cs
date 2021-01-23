    private void ActivateMenus(ToolStripItemCollection items)
    {
        foreach (ToolStripMenuItem item in items)
        {
            item.Visible = true;    
            ActivateMenus(item.DropDown.Items);
        }
    }

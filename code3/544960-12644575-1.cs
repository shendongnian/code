    private void zedGraphControl1_ContextMenuBuilder(
        ZedGraphControl sender, ContextMenuStrip menuStrip, 
        Point mousePt, ZedGraphControl.ContextMenuObjectState objState)
    {
        foreach (ToolStripMenuItem item in menuStrip.Items)
        {
            if ((string)item.Tag == "set_default")
            {
                menuStrip.Items.Remove(item);
                break;
            }
         }
    }

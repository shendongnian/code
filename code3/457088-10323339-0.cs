    public void mnuUncheck()
    {
        foreach (ToolStripMenuItem Item in mnuStripMain.Items)
        {
           Item.Checked = false;
        }
    }

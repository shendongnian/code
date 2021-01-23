    private void FindItAndCheck()
    {
        ToolStripMenuItem item = 
           this.MainMenuStrip.Items.Find("exit", true).FirstOrDefault() 
           as ToolStripMenuItem;
        if (item == null) throw new ApplicationException("...");
        else
        {
            item.Checked = true;
        }
    }

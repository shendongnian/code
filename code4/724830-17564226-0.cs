    // new menu, if you're using designer you should have it already
    ContextMenuStrip mnu = new ContextMenuStrip();
    
    // new tool strip item
    ToolStripMenuItem mnuItem1 = new ToolStripMenuItem();
    mnuItem1.Text = "Some text 1";
    mnuItem1.Name = "mnuItem1";
    
    // new submenu item
    ToolStripMenuItem mnuItem2 = new ToolStripMenuItem();
    mnuItem2.Text = "Some text 2";
    mnuItem2.Name = "mnuItem2";
    
    // connect them...
    mnuItem1.DropDownItems.Add(mnuItem2);
    mnu.Add(mnuItem1);

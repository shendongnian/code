    private Timer _menuTimer = new Timer();
    
    private void MainFrm_Load (object sender, EventArgs e)
    {
        _menuTimer.Interval = 200;
        _menuTimer.Tick += _menuTimer_Tick;
        _rootMenuItem.MouseEnter += commonMenu_MouseEnter;
        _rootMenuItem.MouseLeave += commonMenu_MouseLeave;
        _menuItem1.MouseEnter += commonMenu_MouseEnter;
        _menuItem1.MouseLeave += commonMenu_MouseLeave;
        _menuItem2.MouseEnter += commonMenu_MouseEnter;
        _menuItem2.MouseLeave += commonMenu_MouseLeave;
        _separator.MouseEnter += commonMenu_MouseEnter;
        _separator.MouseLeave += commonMenu_MouseLeave;
        _modeChangingItem.MouseEnter += commonMenu_MouseEnter;
        _modeChangingItem.MouseLeave += commonMenu_MouseLeave;
    }
    private void commonMenu_MouseLeave(object sender, EventArgs e)
    {
        _menuTimer.Stop();
        // Comment this line out if you want none of the items to AutoClose 
        _rootMenuItem.DropDown.AutoClose = true;
        ToolStripMenuItem menuItem = sender as ToolStripMenuItem;
        if (menuItem != null) menuItem.Tag = null;
        ToolStripSeparator separator = sender as ToolStripSeparator;
        if (separator != null) separator.Tag = null;
        _menuTimer.Start();
    }
    private void commonMenu_MouseEnter(object sender, EventArgs e)
    {
        ToolStripMenuItem menuItem = sender as ToolStripMenuItem;
        if (menuItem != null) menuItem.Tag = new object();
        ToolStripSeparator separator = sender as ToolStripSeparator;
        if (separator != null) separator.Tag = new object();
    }
    private void _menuTimer_Tick(object sender, EventArgs e)
    {
        if (_rootMenuItem.Tag == null && _menuItem1.Tag == null &&
                                         _menuItem2.Tag == null &&
                                         _separator.Tag == null &&
                                         _modeChangingItem.Tag == null)
        {
            _rootMenuItem.DropDown.Close();
        }
        _menuTimer.Stop();
    }
    private void _modeChangingItem_Click(object sender, EventArgs e)
    {
        ToolStripMenuItem menuItem = sender as ToolStripMenuItem;
        if (menuItem == null) return;
        // Move this line to Form_Load if you want none of the items AutoClose 
        _rootMenuItem.DropDown.AutoClose = false; // Now the menu stays opened
        [...]
    }

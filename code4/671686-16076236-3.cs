    if(tabControl.TabCount - 1 == tabControl.SelectedIndex)
      return; // No more tabs to show!
    tabControl.SelectedTab.Enabled = false;
    var nextTab = tabControl.TabPages[tabControl.SelectedIndex+1] as TabPage;
    nextTab.Enabled = true;
    tabControl.SelectedTab = nextTab;

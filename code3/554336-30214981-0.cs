    // Hide TabPage and Remove the Header
    this.tabPage1.Hide();
    this.tabPage3.Hide();
    this.tabPage5.Hide();
    tabControl1.TabPages.Remove(tabPage1);
    tabControl1.TabPages.Remove(tabPage3);
    tabControl1.TabPages.Remove(tabPage5);
    
    // Show TabPage and Visible the Header
    tabControl1.TabPages.Insert(0,tabPage1);
    tabControl1.TabPages.Insert(2, tabPage3);
    tabControl1.TabPages.Insert(4, tabPage5);
    this.tabPage1.Show();
    this.tabPage3.Show();
    this.tabPage5.Show();
    tabControl1.SelectedTab = tabPage1;

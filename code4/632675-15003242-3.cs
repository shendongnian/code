    private void closeTab_Click(object sender, EventArgs e)
    {
        // Is the Tab Page the first one?
        if (tabControl1.SelectedTab == tabControl1.TabPages[0])
            return;
        tabControl1.TabPages.Remove(tabControl1.SelectedTab);
    }

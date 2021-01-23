    private void closeTab_Click(object sender, EventArgs e)
    {
        // Is the Tab Page the last one opened?
        if (tabControl1.TabCount == 1)
            return;
        tabControl1.TabPages.Remove(tabControl1.SelectedTab);
    }

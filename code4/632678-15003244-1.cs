    private void newTab_Click(object sender, EventArgs e)
    {
            string title = "TabPage " + (tabControl1.TabCount + 1).ToString();
            TabPage myTabPage = new TabPage(title);
            tabControl1.TabPages.Add(myTabPage);
            WebBrowser wb = new WebBrowser();
            myTabPage.Controls.Add(wb);
            wb.Navigate("google.com");
    }
    private void closeTab_Click(object sender, EventArgs e)
    {
        if(tabControl1.TabPages.Count == 1)
           return;
    
        tabControl1.TabPages.Remove(tabControl1.SelectedTab);
    }

    private void newTab_Click(object sender, EventArgs e)
    {
        string title = "TabPage " + (tabControl1.TabCount + 1).ToString();
        TabPage myTabPage = new TabPage(title);
        
        // Create new WebBrowser instance
        var browser = new WebBrowser();
        browser.Dock = DockStyle.Fill;
        browser.Url = new Uri(@"http://www.google.de");
        // Add the WebBrowser control to the TabPage.
        myTabPage.Controls.Add(browser);
        tabControl1.TabPages.Add(myTabPage);
    }

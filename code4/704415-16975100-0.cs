    WebBrowser browser = new WebBrowser();
    browser.Dock = DockStyle.Fill;
    browser.Url = new System.Uri("http://google.com");
    tabControl1.TabPages.Add(new TabPage("Aba " + (tabControl1.TabCount + 1).ToString()));
    tabControl1.TabPages[tabControl1.TabCount - 1].Controls.Add(browser);
    browser.ProgressChanged += new WebBrowserProgressChangedEventHandler( delegate (object sender, WebBrowserProgressChangedEventArgs events)
        {
            if ((int)events.CurrentProgress > 0)
            {
                toolStripProgressBar1.Maximum = (int)events.MaximumProgress;
                toolStripProgressBar1.Value = (int)events.CurrentProgress;
            }
        });

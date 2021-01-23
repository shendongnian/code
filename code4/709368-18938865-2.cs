    void page_Loaded(object sender, WebBrowserDocumentCompletedEventArgs e)
    {          
    // Wait for Objects to Load...
    delaytimer.Interval = 500;
    delaytimer.Enabled = true;
    delaytimer.Tick += new EventHandler(PageObjects_Loaded);
    delaytimer.Start();
    }
    void PageObjects_Loaded(object sender, WebBrowserDocumentCompletedEventArgs e)
    { 
    // Do your stuff Here...
    }

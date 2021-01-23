    EventWaitHandle DocumentComplete = new EventWaitHandle(false, EventResetMode.AutoReset);
    
    void Form_Activated(object sender, System.EventArgs e)
    {
        new Thread(new ThreadStart(DoWork)).Start();
    }
    
    void Browser_DocumentComplete(object sender, System.Windows.Forms.WebBrowserDocumentCompletedEventArgs e)
    {
        Data = Browser.Document.Body.GetAttribute(some_tag);
        //process "Data" and do other stuff
        DocumentComplete.Set();
    }
    
    void DoWork() {
        for (; ; ) {
            for (; ; ) {
                //Some operation
                Invoke(new NavigateDelegate(Navigate), URL);
                DocumentComplete.WaitOne();
            }
        }
    }
    
    void Navigate(string url) {
        Browser.Navigate(url);
    }
    
    delegate void NavigateDelegate(string url);

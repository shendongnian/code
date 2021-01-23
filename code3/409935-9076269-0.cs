    private void GetWebData()
    {
         ...get web data...
    }
    private void ShowWebData()
    {
        WebBrowser wb = new WebBrowser();
        // other UI stuff
    }
    private void TimerRefresh_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
    {
        GetDataFromWebBrowser();
    }
    private void GetDataFromWebBrowser()
    {
        GetWebData();
        if (this.InvokeRequired)
            this.Invoke(new Action(ShowWebData));
        else
            ShowWebData();
    }

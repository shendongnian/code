    facebookClient = new WebClient();
    facebookClient.DownloadStringCompleted += FacebookDownloadComplete;
    twitterClient = new WebClient();
    twitterClient.DownloadStringCompleted += TwitterDownloadComplete;
    
    private void FacebookDownloadComplete(Object sender, DownloadStringCompletedEventArgs e)
    {
        if (!e.Cancelled && e.Error == null)
        {
            string str = (string)e.Result;
            DisplayFacebookContent(str);
        }
    }
    private void OnFacebookTimer(object sender, ElapsedEventArgs e)
    {
         if( facebookClient.IsBusy) 
             facebookClient.CancelAsync(); // long time should have passed, better cancel
         facebookClient.DownloadStringAsync(facebookUri);
    }

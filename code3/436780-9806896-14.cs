    public void ThreadProc()
    {
        // other code before this....
        foreach (string url in URLs)
        {
           result.URL = url;
           result.Shares = grabber.GetFacebookShares(url);
           Thread.Sleep(0); // may want to take the Sleeps out
           result.Tweets = grabber.GetTweetCount(url);
           Thread.Sleep(0);
           result.PlusOnes = grabber.GetPlusOnes(url);
           Thread.Sleep(0);
        }
    }

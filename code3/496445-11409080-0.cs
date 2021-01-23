    ScrapeResult result = new ScrapeResult();
    string url = (string)sender;
    result.URL = url;
    if (chkFb.Checked)
    {
        result.Shares = grabber.GetFacebookShares(url);
    }
    if (chkTwitt.Checked)
    {
        result.Tweets = grabber.GetTweetCount(url);
    }
    if (chkPlusOne.Checked)
    {
        result.PlusOnes = grabber.GetPlusOnes(url);
    }
    Interlocked.Decrement(ref counter);
    this.Invoke(new ThreadDone(ReportProgress), result);

    private void DownloadInformation()
    {
    WebClient Detail = new WebClient();
    Detail.DownloadStringCompleted += new        DownloadStringCompletedEventHandler(DownloadStringCallback2);
    Detail.DownloadStringAsync(new Uri("http://link/"));
     }
    private static void DownloadStringCallback2 (Object sender, DownloadStringCompletedEventArgs e)
    {
        // If the request was not canceled and did not throw 
        // an exception, display the resource. 
        if (!e.Cancelled && e.Error == null)
        {
            string textString = (string)e.Result;
            Console.WriteLine (textString);
        }
    }

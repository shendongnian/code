    public static string DownloadFile(string url, string path, string filename, Action<string,double> progressNotification,Action finishNotification)
    {
         Action<object, DownloadProgressChangedEventArgs> progressReaction  = (s,e)=>
                  {                               
                          var progress = "Downloaded " + e.BytesReceived + " of " + e.TotalBytesToReceive;
                          var percent = Math.Truncate(e.BytesReceived / (double)e.TotalBytesToReceive * 100);
                          while (client.IsBusy)
                          {
                             progressNotification(progress, percent);
                          }                          
                  };
         WebClient client = new WebClient();
         client.DownloadProgressChanged += progressReaction;
         client.DownloadFileCompleted += (s,e) => finishNotification();
         client.DownloadFileAsync(new Uri(url), path + filename);
    }                           

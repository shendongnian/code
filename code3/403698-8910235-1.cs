    public void DownloadImages()
    {
        HttpWebRequest reqest = (HttpWebRequest)WebRequest.Create(your_url);
        reqest.BeginGetResponse(DownloadImageCallback, reqest1);
    }
    void DownloadImageCallback(IAsyncResult result)
    {
         HttpWebRequest req = (HttpWebRequest)result.AsyncState;
         HttpWebResponse responce = (HttpWebResponse)req1.EndGetResponse(result);
         Stream s = responce.GetResponseStream();
         Deployment.Current.Dispatcher.BeginInvoke(() =>
         {
             bmp = new BitmapImage();
             bmp.SetSource(s);
         });
    }

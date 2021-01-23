    public Image DownloadImageFromURL(string url)
    {
       HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(filename);
       httpWebRequest.AllowWriteStreamBuffering = true;            
       httpWebRequest.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1)";            
       httpWebRequest.Timeout = 30000; //30 seconds
       webResponse = httpWebRequest.GetResponse();    
       webStream = webResponse.GetResponseStream();
       Image downloadImage = Image.FromStream(webStream);            
       webResponse.Close();   
       return downloadImage;
    }

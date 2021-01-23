     private bool Download(string url, string destination)
     {
         try
         {
             WebClient downloader = new WebClient();
             downloader.DownloadFile(url, destination);
             return true;
         }
         catch(WebException webEx)
         {
            //Check (HttpWebResponse)webEx.Response).StatusCode
            // Or
            //Check for webEx.Status
         }
         return false;
     }

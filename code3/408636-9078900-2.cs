    try
        {
            string url = @"http://api.oodle.com/api/v2/listings?key=TEST&region=chicago";
           
            WebClient webClient = new WebClient();
            webClient.Encoding = Encoding.UTF8;
            string result = webClient.DownloadString(url);
    
           }
      catch (Exception ex)
        {
            Response.Write(ex.ToString());
           
        }

       using (System.Net.WebClient webClnt = new System.Net.WebClient())
        {
           webClnt.proxy = proxy;
           var srResult = webClient.DownloadString(srQueryRequest);
        }

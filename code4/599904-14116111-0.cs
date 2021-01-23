    byte[] imageAsByteArray;
    using(var webClient = new WebClient())
    {
        imageAsByteArray = webClient.DownloadData("uri src");
    }
 

    using(WebClient webClient = new WebClient())
    {
        webClient.Encoding = Encoding.UTF8;
        string s = webClient.DownloadString("http://wwww.li.ru");
    }

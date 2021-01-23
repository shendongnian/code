        WebClient webClient = new WebClient();
        string content = webClient.DownloadString("http://free.worldweatheronline.com/feed/weather.ashx?q=Mumbai&format=xml&num_of_days=2&key=api_key");
        XElement xml = XElement.Parse(content);
        using (MemoryStream ms = new MemoryStream())
        {
            xml.Save(ms);
            // use the ms here.
        }

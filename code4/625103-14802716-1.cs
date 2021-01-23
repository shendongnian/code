    string url = "http://free.worldweatheronline.com/feed/apiusage.ashx?key=" + apikey;
    using (WebClient wc = new WebClient())
    {
        string xml = wc.DownloadString(url);
        var xDoc = XDocument.Parse(xml);
        var result = xDoc.Descendants("usage")
                        .Select(u => new
                        {
                            Date = u.Element("date").Value,
                            DailyRequest = u.Element("daily_request").Value,
                            RequestPerHour = u.Element("request_per_hour").Value,
                        })
                        .ToList();
    }

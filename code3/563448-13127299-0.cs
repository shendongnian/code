    public async void SOQuestion(string query)
    {
        var searchUrl = "http://weather.service.msn.com/find.aspx?outputview=search&src=vista&weasearchstr=" + query;
        WebClient wc = new WebClient();
        string xml = await wc.DownloadStringTaskAsync(searchUrl);
        var xDoc = XDocument.Parse(xml);
        var results = xDoc.Descendants("weather")
                            .Select(w => new
                            {
                                Location = w.Attribute("weatherlocationname").Value,
                                Temp = w.Element("current").Attribute("temperature").Value,
                                SkyText = w.Element("current").Attribute("skytext").Value,
                                  
                            })
                            .ToList();
        dataGridView1.DataSource = results;
    }

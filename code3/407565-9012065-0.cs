    var url = "http://eximguru.com/traderesources/pincode.aspx?&GridInfo=Pincode01";
    var web = new HtmlWeb();
    var results = new List<Pincode>();
    while (!String.IsNullOrWhiteSpace(url))
    {
        var doc = web.Load(url);
        var query = doc.DocumentNode
            .SelectNodes("//div[@class='Search']/div[3]//tr")
            .Skip(1)
            .Select(row => row.SelectNodes("td"))
            .Select(row => new Pincode
            {
                PinCode = row[0].InnerText,
                District = row[1].InnerText,
                State = row[2].InnerText,
                Area = row[3].InnerText,
            });
        results.AddRange(query);
        var next = doc.DocumentNode
            .SelectSingleNode("//div[@class='slistFooter']//a[last()]");
        if (next != null && next.InnerText == "Next")
        {
            url = next.Attributes["href"].Value;
        }
        else
        {
            url = null;
        }
    }

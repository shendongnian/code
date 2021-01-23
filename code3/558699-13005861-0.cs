    WebClient webClient = new WebClient();
    string page = webClient.DownloadString("http://www.mufap.com.pk/payout-report.php?tab=01");
    HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
    doc.LoadHtml(page);
    List<List<string>> table = doc.DocumentNode.SelectSingleNode("//table[@class='mydata']")
                .Descendants("tr")
                .Skip(1)
                .Where(tr=>tr.Elements("td").Count()>1)
                .Select(tr => tr.Elements("td").Select(td => td.InnerText.Trim()).ToList())
                .ToList();

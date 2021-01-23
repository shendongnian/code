    WebClient wc = new WebClient();
    string page = wc.DownloadString("http://www.jcao.org/mylkups.asp");
    HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
    doc.LoadHtml(page);
    var values = doc.DocumentNode.SelectNodes("//input[@name='view']")
                    .Select(t => t.Attributes["value"].Value)
                    .ToList();
    wc.Headers["Content-Type"] = "application/x-www-form-urlencoded";
    foreach (var val in values)
    {
        var newpage = wc.UploadString("http://www.jcao.org/myrec.asp", "view=" + HttpUtility.UrlEncode(val));
        Console.WriteLine(newpage);
        //
        //Now Parse that page with HtmlAgilityPack
    }

    public void Test2()
    {
        string html = @"<script type=""text/javascript"">wr(""<span>maddog"");wr(""@"");wr(""website-url.com</span>"")</script>";
            
        var parsedHtml = String.Join("",Regex.Matches(html, @"wr\(\""(.+?)\""\)")
                                                .Cast<Match>()
                                                .Select(m => m.Groups[1].Value));
        HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
        doc.LoadHtml(parsedHtml);
        var eMailAddress = doc.DocumentNode.InnerText;
    }

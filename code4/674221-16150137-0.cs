    string html = @"<span style=""background:lime;Color:Red;"">Contrary to popular belief,.....</span>";
        
    var doc = new HtmlAgilityPack.HtmlDocument();
    doc.LoadHtml(html);
    foreach (var span in doc.DocumentNode.Descendants("span"))
    {
        var style = span.Attributes["style"].Value;
        span.Attributes["style"].Value = String.Join(";", style.Split(';').Where(s => !s.ToLower().Trim().StartsWith("background:")));
       
    }
    var newHtml = doc.DocumentNode.InnerHtml;

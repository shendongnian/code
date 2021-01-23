        string myHtml =
        @"
        <ul class='beverageFacts'>
        <li>
            <span>Vintage</span> 
            <strong>2007&nbsp;</strong>
        </li>
        <li>
            <span>ABV</span> 
            <strong>13,0&nbsp;%</strong>
        </li>
        <li>
            <span>Sugar</span> 
            <strong>5&nbsp;gram/liter</strong>
        </li>";
        //Remove space after and before tag
    myHtml = Regex.Replace(myHtml, @"\s+<", "<", RegexOptions.Multiline | RegexOptions.Compiled);
    myHtml = Regex.Replace(myHtml, @">\s+", "> ", RegexOptions.Compiled | RegexOptions.Multiline);
    
    HtmlDocument doc = new HtmlDocument();
    doc.LoadHtml(myHtml.Replace("/r", "").Replace("/n", "").Replace("/r/n", "").Replace("  ", ""));
    doc.OptionFixNestedTags = true;
    
    HtmlNodeCollection vals = doc.DocumentNode.SelectNodes("//ul[@class='beverageFacts']//span");
    
    var myNodeContent = string.Empty;
    foreach (HtmlNode val in vals)
    {
        if (val.InnerText == "Vintage")
        {
            myNodeContent = val.NextSibling.InnerText;
        }
    }
    
    return myNodeContent;

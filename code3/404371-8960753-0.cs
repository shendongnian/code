        string sContent = "ttt <a href='mailto:someone@example.com'>someemail@mail.com</a> abc email@email.com";
        string sRegex = @"([\w-]+(\.[\w-]+)*@([a-z0-9-]+(\.[a-z0-9-]+)*?\.[a-z]{2,6}|(\d{1,3}\.){3}\d{1,3})(:\d{4})?)";
        Regex Regx = new Regex(sRegex, RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture);
        HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
        doc.LoadHtml(sContent);
        
        var nodes = doc.DocumentNode.SelectNodes("//text()[not(ancestor::a)]");
        foreach (var node in nodes)
        {
            node.InnerHtml = Regx.Replace(node.InnerHtml, @"<a href=""mailto:$0"">$0</a>");
        }
        string fixedContent = doc.DocumentNode.OuterHtml;

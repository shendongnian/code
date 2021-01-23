    public static void BeautifyHtml()
    {
        string input = "<html><body><p>This is some test test<br ><ul><li>item 1<li>item2<</ul></body>";
        HtmlAgilityPack.HtmlDocument test = new HtmlAgilityPack.HtmlDocument();
        test.LoadHtml(input);
        test.OptionOutputAsXml = true;
        test.OptionCheckSyntax = true;
        test.OptionFixNestedTags = true;
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        using (System.IO.TextWriter stringWriter = new System.IO.StringWriter(sb))
        {
            test.Save(stringWriter);
        }
        string beautified = sb.ToString();
        System.Console.WriteLine(beautified);
    }

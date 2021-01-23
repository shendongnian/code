    var sb = new StringBuilder(); 
    var stringWriter = new StringWriter(sb);
    
    string input = "<html><body><p>This is some test test<ul><li>item 1<li>item2<</ul></body>";
    
    var test = new HtmlAgilityPack.HtmlDocument();
    test.LoadHtml(input);
    test.OptionOutputAsXml = true;
    test.OptionCheckSyntax = true;
    test.OptionFixNestedTags = true;
    
    test.Save(stringWriter);
    
    Console.WriteLine(sb.ToString());

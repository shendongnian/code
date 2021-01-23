    string html = @"<option foo1='bar1' value=""1"" foo=bar></option>";
    var doc = new HtmlAgilityPack.HtmlDocument();
    doc.LoadHtml(html);
    var node = doc.DocumentNode.ChildNodes[0];
    //Get all the attributes
    var attributes = new List<HtmlAttribute>(node.Attributes);
    //Remove all the attributes
    node.Attributes.RemoveAll();
    //Insert them again
    foreach (var attr in attributes) {
        //If we found the 'value' atrribute, insert it at the begining
        if (attr.Name == "value")
        {
            node.Attributes.Insert(0, attr);
        }
        else {
            node.Attributes.Add(attr);
        }
    }
    Console.WriteLine(doc.DocumentNode.OuterHtml);

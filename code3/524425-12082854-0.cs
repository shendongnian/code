    //Assumes your document is loaded into a variable named 'document'
    List<string> dataAttribute = new List<string>(); //This will contain the long # in the data attribute
    List<string> spanText = new List<string>();      //This will contain the text between the <span> tags
    HtmlNodeCollection nodeCollection = document.DocumentNode.SelectNodes("//div[@class='wrapper']//li");
    foreach (HtmlNode node in nodeCollection)
    {
        dataAttribute.Add(node.GetAttributeValue("data", "null"));
        spanData.Add(node.SelectSingleNode("span").InnerText);
    }

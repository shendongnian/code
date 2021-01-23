    GeckoNode node = geckoWebBrowser.Document.GetElementsByClassName("button")[0].FirstChild;
    if (NodeType.Element == node.NodeType)
    {
      GeckoElement element = (GeckoElement)node;
      element.Click();
    }
    else
    {
     // Even though GetElementByClassName return type could contain non elements, I don't think
     // it ever would in reality.
     Console.WriteLine("First node is a {0} not an element.", node.NodeType);
    }

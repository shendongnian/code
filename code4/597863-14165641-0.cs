    GeckoNode node = geckoWebBrowser.Document.GetElementsByClassName("button")[0].FirstChild;
    if (NodeType.Element == node.NodeType)
    {
      GeckoElement element = (GeckoElement)node;
    }
    else
    {
     Console.WriteLine("First node is a {0} not an element.", node.NodeType);
    }

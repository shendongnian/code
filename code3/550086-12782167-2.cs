    XmlNodeList emptyElements = xdoc.SelectNodes(@"//*[not(node())]");
    for (int i = emptyElements.Count - 1; i > -1; i--)
    {
         XmlNode nodeToBeRemoved = emptyElements[i];
         nodeToBeRemoved.ParentNode.RemoveChild(nodeToBeRemoved);
    }

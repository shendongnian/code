    string Xpath = string.Format("root/product[@category='{0}']/product[@type='{1}']/product[@name='{2}']", "Soaps", "Washing", "Tide");                      
    xdoc.SelectSingleNode(Xpath).RemoveAll();
    XmlNodeList emptyElements = xdoc.SelectNodes(@"//*[not(node())]");
    for (int i = emptyElements.Count - 1; i > -1; i--)
    {
          XmlNode nodeToBeRemoved = emptyElements[i];
          nodeToBeRemoved.ParentNode.RemoveChild(nodeToBeRemoved);
    }
    xdoc.Save(strFilename);

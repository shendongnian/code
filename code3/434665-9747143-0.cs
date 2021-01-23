    XmlDocument doc = new XmlDocument();
    doc.LoadXml("yourxml");
    XmlNode root = doc.FirstChild;
    //Display the contents of the child nodes.
    if (root.HasChildNodes)
    {
      for (int i=0; i<root.ChildNodes.Count; i++)
      {
        Console.WriteLine(root.ChildNodes[i].InnerText);
      }
    }

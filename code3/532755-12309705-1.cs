    void PrintMenu(XElement menuElement, string prefix)
    {
      string newPrefix = prefix + "-";
      foreach (XElement subMenuElement in menuElement.XPathSelectElements("MenuItem")) {
        Console.Writelin(prefix+(string)subMenuElement.Attribute("Name"));
        PrintMenu(subMenuElement, newPrefix);
      }
    }
    . . . 
    XElement doc = XElement.Parse(DataXml); 
    PrintMenu(doc, String.Empty);

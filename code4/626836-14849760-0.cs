    XmlDocument doc = new XmlDocument();
    doc.Load("Data.xml");
    int count = doc.SelectNodes("Data/DataClass").Count;
    for (int i = 1; i < count; i++)
    {
      string xpath = "/Data/DataClass[" + i + "]";
      XmlNode node = doc.SelectSingleNode(xpath);
      XmlNodeList subnode = node.ChildNodes;
      string pathO = "";
      string pathI = subnode[0].InnerText;
      string prefix = subnode[2].InnerText;
      string freq = subnode[3].InnerText;
      string[] filenames = Directory.GetFiles(pathI);
      node.ParentNode.RemoveChild(doc.SelectSingleNode(xpath));
      doc.Save("Data.xml");
      Parallel.ForEach(var filename in filenames)
      {
            pathO = subnode[1].InnerText;
            pathO = pathO + "\\" + prefix;
            string fname = Path.GetFileName(filename);
            pathO = pathO + fname;
            System.IO.File.Move(filename, 
      }
    } 

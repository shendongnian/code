    private string ReadHTML(string html)
    {
      System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
      doc.LoadXml(html);
      System.Xml.XmlElement element = doc.DocumentElement;
      //This commented-out approach works and might be preferred if you want to iterate
      //over a node set instead of choosing just one node
      //string key = "//div[@class='right']";
      //System.Xml.XmlNodeList setting = element.SelectNodes(key);
      //return setting[1].LastChild.InnerText;
      // This xpath appraoch will let you select exactly one node:
      string key = "((//div[@class='right'])[2])/child::text()[last()]";
      System.Xml.XmlNode setting = element.SelectSingleNode(key);
      return setting.InnerText;
    }

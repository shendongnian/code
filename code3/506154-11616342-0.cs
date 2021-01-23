    private string ReadHTML(string html)
    {
      System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
      doc.LoadXml(html);
      System.Xml.XmlElement element = doc.DocumentElement;
      string key = "//div[@class='right']";
      System.Xml.XmlNodeList setting = element.SelectNodes(key);
      
      return setting[1].LastChild.InnerText;
    }

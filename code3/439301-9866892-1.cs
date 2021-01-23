     XmlDocument doc = new XmlDocument();
      doc.LoadXml(xml);
      var nodes = doc.DocumentElement.ChildNodes;
      StringBuilder result = new StringBuilder();
      foreach (XmlNode node in nodes)
      {
        if (!node.Name.Equals("second"))
        {
          result.Append(node.InnerText);
          result.Append(" ");
        }
      }

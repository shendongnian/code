        Dictionary<string, string> dictionary = new Dictionary<string,string>();
        foreach (XmlNode node in nodeList)
        {
            dictionary.Add(node.ChildNodes[0].InnerText, node.ChildNodes[1].InnerText);
          
        }

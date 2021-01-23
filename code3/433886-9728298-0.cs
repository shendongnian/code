    void DeleteNodes(XmlNode root, string deleteName)
    {
      foreach(XmlNode node in root.ChildNodes)
      {
        if (node.Name == deleteName)
        {
          root.RemoveChild(node);
        }
        else
        {
          DeleteNodes(node,deleteName);
        }
      }
    }

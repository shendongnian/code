    using (var writer = System.IO.CreateText("myFile.txt"))
    {
      foreach (node in nodeList)
      {
          writer.WriteLine(node.OuterXml);   // InnerXml to get only the content
      }
    }

    using (var writer = System.IO.File.CreateText("myFile.txt"))
    {
      foreach (node in nodeList)
      {
          writer.WriteLine(node.OuterXml);   // InnerXml to get only the content
      }
    }

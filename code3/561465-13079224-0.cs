    public static class MyReaderClass
    {
      public static List<string> ReadNames(string path)
      {
        var items = new List<string>();
        XDocument xDoc = XDocument.Load(path);
        foreach (XElement element in xDoc.Descendants("Name"))
        {
          items.Add(element.Value);
        }
        return items;
      }
    }

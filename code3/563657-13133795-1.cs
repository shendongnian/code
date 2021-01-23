    using(FileStream fs = new FileStream("somedata.xml",FileMode.Open))
    {
      var result = XDocument.Load(fs).Descendants("BookOptions").
                                      Descendants("Property").
                                      Where(c => { return c.Attribute("Name").Value.Trim() == "IsAuthorFilterNeeded"; }).
                                      Descendants().Select(xe => xe.Attribute("Value"));
      result.ToList().ForEach((val) => Console.WriteLine(val));
    }

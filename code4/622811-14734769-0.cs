    XDocument xdoc = XDocument.Load("test.xml");
    XNamespace ns = "http://private.com";
    var entries = xdoc.Descendants("Logs")
                      .Elements(ns + "LogEntry")
                      .Select(e => new {
                          Date = (DateTime)e.Element(ns + "DateTime"),
                          Sequence = (int)e.Element(ns + "Sequence"),
                          AppID = (string)e.Element(ns + "AppID")
                      }).ToList();   
    
    Console.WriteLine("Entries count = {0}", entries.Count);    
    foreach (var entry in entries)
    {
        Console.WriteLine("{0}\t{1} {2}", 
                          entry.Date, entry.Sequence, entry.AppID);
    }

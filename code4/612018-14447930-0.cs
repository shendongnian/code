    var xDoc = XDocument.Load(XML);
    var paths = xDoc.Root.Elements("Paths");
    var res = from p in paths
              select new
                         {
                             outputPath = p.Element("outputPath").Attribute("value").Value,
                             outputPath_today = p.Element("outputPath_today").Attribute("value").Value,
                             log = p.Element("log").Attribute("value").Value
                        };
     foreach(path in res)
     {
          System.Console.WriteLine(path.outputPath);
          System.Console.WriteLine(path.outputPath_today);
          System.Console.WriteLine(path.log);
          // or do anything you want to do with those properties
     }

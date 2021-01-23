      var xmlDocument = XDocument.Load(@"C:\test.xml");
      var results = xmlDocument.Elements("DiagReport").Select(x => new 
      {
          ToolVersion = x.Descendants("ToolVersion").FirstOrDefault().Value,
          LicensingStatus = x.Descendants("LicensingStatus").FirstOrDefault().Value,
          Result = x.Descendants("Result").FirstOrDefault().Value
      });
      // print results
      foreach (var item in results)
      {
          Console.WriteLine("ToolVersion: {0}, LicensingData: {1}, Result: {2}", item.ToolVersion, item.LicensingStatus, item.Result);
      }

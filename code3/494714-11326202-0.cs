     List<Merc> m = null;
     XNamespace ns = "http://webService";
     using (XmlReader reader = XmlReader.Create(new StringReader(result)))
          {
             XDocument doc = XDocument.Load(reader, LoadOptions.SetLineInfo);
             m = (from downloadInfoReturn in doc.Descendants(ns + "downloadInfoReturn")
                       select new Merc
                           {
                             CompanyName = downloadInfoReturn.Element(ns+ "companyName").Value
                            }).ToList<Merc>();
                }
        Console.WriteLine(m.Count); // this will show 1

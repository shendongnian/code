    var res = XDocument.Load(@"c:\temp\test.xml");
    var results = res.Descendants("R").Where(r => r.Element("T") != null)
                     .Select(r => new GoogleSearchResultItem
                     {
                         PageSummary = new PageSummary
                             {
                                 Title = r.Element("T").Value,
                                 LinkUrl = r.Element("U").Value,
                                 Description = r.Element("S").Value,
                                 ProgramId = r.Descendants("Attribute").Where(x => x.Attribute("name").Value == "programid").Select(x => x.Attribute("value").Value).FirstOrDefault()
                             }
                     });

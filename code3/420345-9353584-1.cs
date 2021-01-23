    using System.Xml.XPath;
    ...
    var path = "<Your path>";
    var doc = XElement.Load(path);
    var subPages = doc.XPathSelectElements("//subpage[@pageId != '']")
                      .Select(x => new
                                   {
                                       Id = Convert.ToInt32(x.Attribute("pageId").Value,
                                       SubTitle = x.Attribute("subtitle").Value,
                                       Enabled = Convert.ToBoolean(x.Attribute("enabled").Value)
                                   }
                      )
                      .ToDictionary(u => u.Id, u => new Tuple<int, string, string>(u.Id, u.SubTitle, u.Enabled)

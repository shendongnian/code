    using System.Xml.XPath;
    ...
    var path = "<Your path>";
    var doc = XElement.Load(path);
    var subPages = doc.XPathSelectElements("//Subpage[@pageId != '']")
                      .Select(x => new
                                   {
                                       Id = Convert.ToInt32(x.Attribute("pageId").Value,
                                       SubTitle = xAttribute("subtitle").Value,
                                       Enabled = Convert.ToBoolean(xAttribute("enabled").Value)
                                   }
                      )
                      .ToDictionary(u => u.Id, u => new Tuple<int, string, string>(u.Id, u.SubTitle, u.Enabled)

        var sitegroupNameSelectedByUser = "execise";
        var siteName = "E";
        var siteUrl = "e.aspx";
        
        XDocument yourFile = XDocument.Load(@"yourFilename.xml");
        XElement existingSitegroup = xmldoc.XPathSelectElement("sitegroups/sitegroup[@name = sitegroupNameSelectedByUser]");
        
            if (existingSitegroup == null)
            {
                XElement sitegroup = new XElement("sitegroup",
                                new XAttribute("name", sitegroupNameSelectedByUser),
                                new XElement("site", 
                                    new XAttribute("name", siteName),
                                    new XAttribute("url", siteUrl));
                
                yourFile.Add(sitegroup);
            }
    
        yourFile.Save("new-filename.xml");

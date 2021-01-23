    string xml;
                        OneApplication.GetPageContent(page.Attributes["ID"].Value, out xml, PageInfo.piAll);
                        var doc = XDocument.Parse(xml);
                        var nodes = doc.Descendants();
    
                        foreach (var node in nodes)
                        {
                            if (node.Attribute("objectID") != null)
                            {
                                node.Attributes("objectID").Remove();
                            } else if (node.Attribute("ID") != null)
                            {
                                node.Attribute("ID").Value = "";
                            }
                        }

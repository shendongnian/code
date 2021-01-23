    XApplication[] appList = (from xapp in applicationXml.Elements("category").Elements("app")
                               where xapp.Element("name").Value.ToLower().Contains(txtSearch.Text.ToLower())
                               select new XApplication
                               {
                                    Name = xapp.Element("name").Value,
                                    Category = xapp.Parent.Attribute("cat").Value
                               }).ToArray();

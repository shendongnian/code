    var SListItem = 
                    (
                        from xmlSList in xDoc.Descendants("selectListItemDefinition")
                        from item in xmlSList.Elements("item")
                        select new SelectListItem
                        {
                            Key = item.Attribute("key").Value,
                            Value = item.Attribute("value").Value
                        }
                    ).ToList();

                XDocument xDoc = /* populate from somewhere */
    
                XNamespace nsPlaceHolder = XNamespace.Get("http://schemas.microsoft.com/developer/msbuild/2003");
    
      XNamespace ns = string.Empty;
    
    
                var list1 = from list in xDoc.Descendants(ns + "cards")
                            from item in list.Elements(ns + "card")
                            /* where item.Element(ns + "card") != null */
                        select new
                           {
    
                               PicURL = item.Attribute("picURL").Value,
                               MyName = (item.Element(ns + "name") == null) ? string.Empty : item.Element(ns + "name").Value
                           };
    
    
                foreach (var v in list1)
                {
                    Console.WriteLine(v.ToString());
                }

    var doc = XDocument.Load("XmlFile1.xml");
    var hfIds = (from hf in doc.Descendants("hf").Attributes("id")
                             select hf.Value).Distinct(StringComparer.Ordinal).ToList();
    
    
                bool addFlag = true;
    
                foreach (var c in doc.Descendants("lze"))
                {
                    foreach (var hfid in hfIds)
                    {
                        addFlag = true;
                        foreach (var attr in c.Descendants("lz").Attributes("hid"))
                        {
                            if (hfid == attr.Value)
                            {
                                addFlag = false;
                                break;
                            }
    
                        }
                        if (addFlag)
                        {
                            c.Add(new XElement("lz", new XAttribute("hid", hfid),
                                new XElement("ps",
                                        new XElement("p"),
                                    new XElement("Text"),
                                    new XElement("Content"))));
                        }
                    }
                }
    
    
                // Adding the p elements to the above added lz elements
                var distinctPIds = (from hf in doc.Descendants("lz").Descendants("p")
                                    select hf).GroupBy(x => x.Value).Select(x => x.First()); ;
    
                addFlag = true;
                XElement a = null;
                foreach (var c in doc.Descendants("lz").Descendants("ps"))
                {
                    foreach (var c3 in distinctPIds)
                    {
                        addFlag = true;
                        foreach (var c2 in c.Descendants("p"))
                        {
                            if (XNode.DeepEquals(c2, c3))
                            {
                                addFlag = false;
                                break;
                            }
                            a = c3;
                        }
                        if (addFlag)
                            c.Add(a);
                    }
                }
            }

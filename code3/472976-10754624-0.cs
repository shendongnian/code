     var doc = XDocument.Load(reader);
                        IEnumerable<XElement> mainCats =
                            doc.Descendants("product").Descendants("category").Select(r =>
                                new XElement("maincat", new XElement("name", r.Element("name").Value),
                                    r.Descendants("subcat").Select(s => new XElement("subcat", new XElement("name", s.Element("name").Value)))));
    
    
                        var cDoc = new XDocument(new XDeclaration("1.0", "utf-8", null), new XElement("root"));
                        cDoc.Root.Add(mainCats);
                        var cachedCategoryDoc = cDoc.ToString();

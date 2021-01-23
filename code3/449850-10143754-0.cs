    // raw - your XML
    string raw = File.ReadAllText("c:\\test1.xml");
    // create root node manually
    string xml = "<root>" + raw + "</root>";
    var xdoc = XDocument.Parse(xml);       
    // contains IEnumerable<string>
    var damagedValues = xdoc.Descendants("attribute")
                            .Where(e => e.Attribute("name") != null 
                                        && e.Attribute("name").Value == "Damage")
                            .Select(x => x.Attribute("value").Value);

    // define a XDocument and other variables
    XDocument doc;
    var url = "http://ups.com/?TrackingNumber=";
    var dec = new XDeclaration("1.0", "utf-8", "yes");
    // parse the rows
    dt.Rows.Cast<DataRow>()
        // grouping by [OrderID]
        .GroupBy(r => r["OrderID"])
        .ToList().ForEach(group =>
        {
            // create a new instance
            doc = new XDocument();
            doc.Document.Declaration = dec;
            var root = new XElement("OrderSet");
            doc.Add(root);
            // parse the group of rows
            group.ToList().ForEach(item =>
            {
                // add an element based on the XML content in 
                // the [UserDefXml] column
                var e = XElement.Parse(item["UserDefXml"].ToString())
                    .Descendants("Order").First();
                // get the document
                var document = e.Element("Document");
                // add the attribute
                XAttribute attribute =
                    new XAttribute("TrackingURL",
                        String.Format("{0}{1}",
                            url,
                            document.Attribute("TrackingNumber").Value));
                document.Add(attribute);
                // add the element to the document's root
                root.Add(e);
            });
            doc.Save(String.Format("{0}.xml", group.Key));
        });

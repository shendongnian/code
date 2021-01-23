    dt.Rows.Cast<DataRow>().GroupBy(r => r["OrderId"]).ToList().ForEach(group =>
    {
        var doc = new XDocument();
        var url = "http://ups.com/?TrackingNumber=";
        var dec = new XDeclaration("1.0", "utf-8", "yes");
        doc.Document.Declaration = dec;
        var root = new XElement("OrderSet");
        doc.Add(root);
        group.ToList().ForEach(item =>
        {
            var e = XElement.Parse(item["UserDefXml"].ToString())
                .Descendants("Document").First();
            XAttribute attribute =
                new XAttribute("TrackingURL",
                    String.Format("{0}{1}",
                        url,
                        e.Attribute("TrackingNumber").Value));
            e.Add(attribute);
            root.Add(e);
        });
        doc.Save(String.Format("{0}.xml", group.Key));
    });

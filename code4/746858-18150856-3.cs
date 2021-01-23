    using System;
    using System.Data;
    using System.Linq;
    using System.Xml.Linq;
    class Program
    {
        const string url = "http://ups.com/?TrackingNumber=";
        static void Main(string[] args)
        {
            // dummy data
            var dt = new DataTable();
            dt.Columns.Add("OrderID", typeof(int));
            dt.Columns.Add("UserDefXml");
            dt.Rows.Add(1, "<OrderSet><Order item=\"XYZ\"><Document ShipDate=\"08/09/2013\" TrackingNumber=\"1Z1\"/></Order></OrderSet>");
            dt.Rows.Add(1, "<OrderSet><Order item=\"ABC\"><Document ShipDate=\"08/07/2013\" TrackingNumber=\"1Z2\"/></Order></OrderSet>");
            dt.Rows.Add(2, "<OrderSet><Order item=\"ABC\"><Document ShipDate=\"08/11/2013\" TrackingNumber=\"1Z3\"/></Order></OrderSet>");
            // define a XDocument and a declaration
            XDocument doc;
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
                    // save the file
                    doc.Save(String.Format("{0}.xml", group.Key));
                });
        }
    }

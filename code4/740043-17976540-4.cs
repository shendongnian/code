    WebClient client = new WebClient();
    string content = client.DownloadString(url);
    XDocument xdoc = XDocument.Parse(content);
    XNamespace ns = "http://www.namespaceuri.com/Admin/ws";
    var payments = from p in xdoc.Descendants(ns + "PaymentMethod")
                    select new {
                        Sale = (decimal)p.Element(ns + "Sale"),
                        SaleCount = (int)p.Element(ns + "Sale_Cnt"),
                        PaymentType = (string)p.Element(ns + "Payment_Type_ID")
                    };

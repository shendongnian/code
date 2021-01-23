    // XDocument.Parse will load a string into the XDocument object.
    XDocument xDoc = XDocument.Parse(response);
    // XNamespace is required in order to parse the document.
    XNamespace ns = "GlobalPayments";
  
    var resp = (from x in xDoc.Descendants(ns + "ExtData")
                select new
                {
                    ExtData = x.Value,
                    BatchNum = x.Element(ns + "BatchNum").Value,
                    MID = x.Element(ns + "MID").Value,
                    TransID = x.Element(ns + "TransID").Value
                }).SingleOrDefault();

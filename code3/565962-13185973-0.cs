    XElement myElement = XElement.Load("Inquiries.xml");
    var query = from s in myElement.Elements("Inquiry")
                select new
                {
                    InquiryId = Convert.ToInt32(s.Element("InquiryId").Value),
                    FirstName = s.Element("FirstName").Value,
                    LastName = s.Element("LastName").Value,
                    LineItems = (from l in s.Element("LineItems").Elements("LineItem")
                                select new
                                {
                                    Quantity = Convert.ToInt32(l.Attribute("quantity").Value),
                                    PartNumber = l.Attribute("partnumber").Value
                                }).ToList()
                };
    var result = query.ToList();

        public void Test()
        {
            var inquiries = XElement.Load("Test.xml").Elements("Inquiry")
                .Select(i => new Inquiry
                            {
                                InquiryId = int.Parse(i.Element("InquiryId").Value),
                                FirstName = i.Element("FirstName").Value,
                                LastName = i.Element("LastName").Value,
                                LineItems = i.Elements("LineItems").Descendants()
                                    .Select(li => new LineItem
                                        {
                                            Quantity = int.Parse(li.Attribute("quantity").Value),
                                            PartNumber = li.Attribute("partnumber").Value
                                        }).ToList()
                            }).ToList();
        }
    }
    public class Inquiry
    {
        public int InquiryId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<LineItem> LineItems { get; set; }
    }
    public class LineItem
    {
        public int Quantity { get; set; }
        public string PartNumber { get; set; }
    }

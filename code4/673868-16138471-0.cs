    public class Foo : IXmlSerializable
        {
            public Foo()
            {
                ApproxPriceList = new List<ApproxPriceElement>();
            }
    
            public List<ApproxPriceElement> ApproxPriceList { get; set; }
    
            public XmlSchema GetSchema()
            {
                return null;
            }
    
            public void ReadXml(XmlReader reader)
            {
                while (reader.Read())
                {
                    if (reader.IsStartElement())
                    {
                        switch (reader.LocalName)
                        {
                            case "approxPrice":
                                {
                                    var approxPrice = new ApproxPriceElement();
    
                                    approxPrice.Currency = reader.GetAttribute("currency");
    
                                    var approxPriceValue = reader.ReadElementContentAsString();
    
                                    if (!string.IsNullOrEmpty(approxPriceValue))
                                    {
                                        approxPrice.ApproxPrice = decimal.Parse(approxPriceValue);
                                    }
    
                                    ApproxPriceList.Add(approxPrice);
                                }
                                break;
                        }
                    }
                }
            }
    
            public void WriteXml(XmlWriter writer)
            {
                writer.WriteStartElement("approxPriceList");
                foreach (var approxPrice in ApproxPriceList)
                {
                    writer.WriteStartElement("approxPrice");
                    writer.WriteAttributeString("currency", approxPrice.Currency);
                    writer.WriteString(approxPrice.ApproxPrice.ToString());
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
            }
        }
    
        public class ApproxPriceElement
        {
            public string Currency { get; set; }
    
            public decimal? ApproxPrice { get; set; }
        }

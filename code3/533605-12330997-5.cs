     string sXml = @"<Book>
                                 <Title>Introduction to c#</Title>
                                <Publisher>John Smith</Publisher>
                                <Year>2012</Year>
                                </Book>";
                XmlAttributeOverrides overrides = new XmlAttributeOverrides();
                XmlAttributes PublisherAttributes = new XmlAttributes();
                XmlAttributes YearAttributes = new XmlAttributes();
                PublisherAttributes.XmlElements.Add(new XmlElementAttribute("Publisher"));
                YearAttributes.XmlElements.Add(new XmlElementAttribute("Year"));
                overrides.Add(typeof(Book), "Publisher", PublisherAttributes);
                overrides.Add(typeof(Book), "Year", YearAttributes);
               XmlSerializer ser = new XmlSerializer(typeof(Book), overrides);
               System.IO.TextReader oReader = new System.IO.StringReader(sXml);
               Book oBook = (Book) ser.Deserialize(oReader);

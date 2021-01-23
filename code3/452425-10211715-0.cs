            var settings = new XmlWriterSettings
            {
              Indent = true,
              IndentChars = " ",
              OmitXmlDeclaration = true,
              Encoding = new UTF8Encoding(false),
            };
            using (var textReader = new StringReader(<YOUR STRING HERE>))
            {
                var xmlReader = XmlReader.Create(textReader);
                var feed = SyndicationFeed.Load(xmlReader);
                foreach (var item in feed.Items)
                {
                    using (var tempStream = new MemoryStream())
                    {
                        using (var tempWriter = XmlWriter.Create(tempStream, settings))
                        {
                            item.Content.WriteTo(tempWriter, "Content", "");
                            tempWriter.Flush();
                            // Get the content as XML.
                            var contentXml = Encoding.UTF8.GetString(tempStream.ToArray());
                            var contentDocument = XDocument.Parse(contentXml);
                            // Find the properties element.
                            var propertiesName = XName.Get("properties", "http://schemas.microsoft.com/ado/2007/08/dataservices/metadata");
                            var propertiesElement = contentDocument.Descendants(propertiesName)
                                                                   .FirstOrDefault();
                            // Find all text elements.
                            var textName = XName.Get("Text", "http://schemas.microsoft.com/ado/2007/08/dataservices");
                            var textElements = propertiesElement.Descendants(textName);
                            foreach (var textElement in textElements)
                            {
                                Console.WriteLine("Translated word: {0}", textElement.Value);
                            }
                        }
                    }
                }
            }

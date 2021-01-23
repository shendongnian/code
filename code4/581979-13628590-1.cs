            using (MemoryStream memStm = new MemoryStream())
            {
                // Serialize the object using the standard DC serializer.
                s.WriteObject(memStm, graph);
                // Fix the memstream location.
                memStm.Seek(0, SeekOrigin.Begin);
                // Load the serialized document.
                XDocument document = XDocument.Load(memStm);
                foreach (KeyValuePair<string, ItemToAmend> kvp in _processedDateTimes)
                {
                    // Locate the datetime objects.
                    IEnumerable<XElement> t = from el in document.Descendants(XName.Get(kvp.Value.ProperyName, kvp.Value.PropertyNamespace))
                                              select el;
                    // Add the attribute to each element.
                    foreach (XElement e in t)
                    {
                        string convertedDate = string.Empty;
                        if (!string.IsNullOrEmpty(e.Value))
                        {
                            DateTime converted = DateTime.Parse(e.Value);
                            convertedDate = string.Format(new MyBtecDateTimeFormatter(), "{0}", converted);
                        }
                        e.Add(new XAttribute(XName.Get("dval"), convertedDate));
                    }
                }
                // Write the document to the steam.
                document.Save(writer);
            }

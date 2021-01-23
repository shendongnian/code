    using (XmlReader reader = cmd.ExecuteXmlReader())
                {
                   while (!reader.EOF)
                    {
                        results.Root.Add(XElement.Parse(reader.ReadOuterXml()));
                        count += 1;
                    }
                }

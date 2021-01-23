    using (XmlReader reader = cmd.ExecuteXmlReader())
                {
                   reader.Read(); //For initial first read.
                   while (!reader.EOF)
                    {
                        results.Root.Add(XElement.Parse(reader.ReadOuterXml()));
                        count += 1;
                    }
                }

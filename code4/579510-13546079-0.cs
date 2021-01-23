      public static string BeautifyXmlDocument(XmlDocument doc)
            {
                using (MemoryStream sb = new MemoryStream())
                {
                    XmlWriterSettings s = new XmlWriterSettings();
                    s.Indent = true;
                    s.IndentChars = "  ";
                    s.NewLineChars = "\r\n";
                    s.NewLineHandling = NewLineHandling.Replace;
                    s.Encoding = new UTF8Encoding(false);
                    using (XmlWriter writer = XmlWriter.Create(sb, s))
                    {
                        doc.Save(writer);
                        return Encoding.UTF8.GetString(sb.ToArray());
                    }
                }
            }

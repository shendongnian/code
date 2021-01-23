        public static string IndentedPrint(XmlDocument doc)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.Unicode))
                {
                    xmlTextWriter.Formatting = Formatting.Indented;
                    doc.WriteContentTo(xmlTextWriter);
                    xmlTextWriter.Flush();
                    memoryStream.Flush();
                    memoryStream.Position = 0;
                    using (StreamReader sr = new StreamReader(memoryStream))
                    {
                        return sr.ReadToEnd();
                    }
                }
            }
        }

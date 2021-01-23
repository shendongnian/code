            using (var f = new FileStream("C:\\ui.xml",      FileMode.Append,FileAccess.Write,FileShare.Write))
                {
                    using (XmlWriter writer = XmlWriter.Create(f))                 
                    {
                        writer.WriteStartElement(subCtrl.Name);
                        generateXml(subCtrl);
                        writer.WriteEndElement();
                    }
                }

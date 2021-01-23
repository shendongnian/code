     if (!System.IO.File.Exists(path))
            {
                //Create neccessary nodes
                XmlDeclaration declaration = doc.CreateXmlDeclaration("1.0", "UTF-8", "yes");
                XmlComment comment = doc.CreateComment("This is an XML Generated File");
                doc.AppendChild(declaration);
                doc.AppendChild(comment);
                doc.AppendChild(doc.CreateElement("Root"));
            }

                XDocument doc = new XDocument(new XDeclaration("1.0", "UTF-8","d"));
                doc.Add(new XElement("MyRoot", "Value blah"));
               
                
                using (var str = new StringWriter())
                using (var xmlTextWriter = new XmlTextWriter(str))
                {
                    xmlTextWriter.Formatting = Formatting.Indented;
                    xmlTextWriter.Indentation = 4;
    
                    xmlTextWriter.WriteRaw(doc.Declaration.ToString().ToUpper());
    
                    foreach (var xElement in doc.Elements())
                    {
                       xmlTextWriter.WriteElementString(xElement.Name.ToString(), xElement.Value);
                    }
                    
                    var finalOutput = str.ToString();
                }

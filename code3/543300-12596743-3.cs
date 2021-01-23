                    XmlTextWriter textWriter = new XmlTextWriter("yourpath", null);
                    // Opens the document
                    textWriter.WriteStartDocument();
    
    textWriter.WriteStartElement("root");
    textWriter.WriteAttributeString("xmlns", "x", null, "urn:1");
    
                    // Write comments
                    textWriter.WriteComment("First Comment XmlTextWriter Sample Example");
                    
    textWriter.WriteEndElement();
    
    
                    // Ends the document.
                    textWriter.WriteEndDocument();
                    // close writer
                    textWriter.Close();

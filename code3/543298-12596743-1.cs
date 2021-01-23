                XmlTextWriter textWriter = new XmlTextWriter("yourpath", null);
                // Opens the document
                textWriter.WriteStartDocument();
                // Write comments
                textWriter.WriteComment("First Comment XmlTextWriter Sample Example");
                
                // Write first element
                textWriter.WriteStartElement("Student");
                // Ends the document.
                textWriter.WriteEndDocument();
                // close writer
                textWriter.Close();

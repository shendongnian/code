I did this, which keeps everything dynamic no matter which XDocument you are using:
    private void WriteToXml(XDocument xDoc, string filePath)
    {
        // Gets the root XElement of the XDocument
        XElement root = xDoc.Root;
        
        // Using a FileStream for streaming to a file:
        // Use filePath.
        // If it's a new XML doc then create it, else open it.
        // Write to file.
        using (FileStream writer = 
               new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write))
        {
            // For XmlWriter, it uses the stream that we created: writer.
            using (XmlWriter xmlWriter = XmlWriter.Create(writer))
            {
                // Creates a new XML file. The false is for "StandAlone".
                xmlWriter.WriteStartDocument(false);
                // Writes the root XElement Name.
                xmlWriter.WriteStartElement(root.Name.LocalName);
                // Foreach parent XElement in the Root...
                foreach (XElement parent in root.Nodes())
                {
                    // Write the parent XElement name.
                    xmlWriter.WriteStartElement(parent.Name.LocalName);
                    // Foreach child in the parent...
                    foreach (XElement child in parent.Nodes())
                    {
                        // Write the node with XElement name and value.
                        xmlWriter.WriteElementString(child.Name.LocalName, child.Value);
                    }
                    // Close the parent tag.
                    xmlWriter.WriteEndElement();
                }
                // Close the root tag.
                xmlWriter.WriteEndElement();
                // Close the document.
                xmlWriter.WriteEndDocument();
                // Good programming practice, manually flush and close all writers
                // to prevent memory leaks.
                xmlWriter.Flush();
                xmlWriter.Close();
            }
            // Same goes here.
            writer.Flush();
            writer.Close();
        }
    }

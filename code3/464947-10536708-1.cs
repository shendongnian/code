      DataSet newDataSet = new DataSet("New DataSet");
    
        // Read the XML document back in. 
        // Create new FileStream to read schema with.
        System.IO.FileStream fsReadXml = 
            new System.IO.FileStream
            (xmlFilename, System.IO.FileMode.Open);
    
        // Create an XmlTextReader to read the file.
        System.Xml.XmlTextReader xmlReader = 
            new System.Xml.XmlTextReader(fsReadXml);
    
        // Read the XML document into the DataSet.
        newDataSet.ReadXml(xmlReader);
    
        // Close the XmlTextReader
        xmlReader.Close();

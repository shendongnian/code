    using(DataTable dTable = ..something..)
    using(DataSet dS = new DataSet())
    using(XmlTextWriter xmlStream = new XmlTextWriter("FILENAME.XML", Encoding.UTF8))
    {
        //set xml to be formatted so it can be easily red by human
        xmlStream.Formatting = Formatting.Indented;
        xmlStream.Indentation = 4;
        //add table to dataset
        dS.Tables.Add(dTable);
        
        //call the mentioned function so it will set all DBNull values in dataset
        //to string.Empty
        addEmptyElementsToXML(dS);
        
        //write xml to file
        xmlStream.WriteStartDocument();
        dS.WriteXml(xmlStream);
    }

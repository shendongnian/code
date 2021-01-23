    var path = @"C:\Dev\sample.xml";
    
    string xml;
    
    var mRows = 30;
    var mColumns = 50;
    
    var options = new XmlWriterSettings { Indent = true };
    using (var stringWriter = new StringWriter())
    {
        using (var writer = XmlWriter.Create(stringWriter, options))
        {
            writer.WriteStartDocument();
            writer.WriteStartElement("Board");
            writer.WriteAttributeString("Rows", mRows.ToString());
            writer.WriteAttributeString("Columns", mColumns.ToString());
            writer.WriteEndElement();
            writer.WriteEndDocument();
        }
        xml = stringWriter.ToString();
        
        if(File.Exists(path))
            File.Delete(path);
        
        using(var stream = File.OpenWrite(path))
        using(var writer = new StreamWriter(stream, Encoding.Unicode))
        {
            writer.Write(xml);
        }
    }
    
    Console.Write(xml);
    
    using(var stream = File.OpenRead(path))
    using(var reader = XmlReader.Create(stream))
    {
        reader.Read();
    }
    
    File.Delete(path);

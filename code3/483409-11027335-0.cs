    // Removed bad try/catch block - don't just catch Exception, and don't
    // just swallow exceptions
    MemoryStream memoryStream = new MemoryStream();
    XmlSerializer xs = new XmlSerializer(typeof(WorkItem));
    XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);
    xs.Serialize(xmlTextWriter, p);
    // Removed pointless conversion to/from string
    // Removed pointless BinaryWriter (just use the stream)
    // An alternative would be memoryStream.WriteTo(clientStream);
    byte[] data = memoryStream.ToArray();
    clientStream.Write(data, 0, data.Length);
    Console.WriteLine(" send.." + data);
    // Removed Close calls - you should use "using" statements to dispose of
    // streams automatically.

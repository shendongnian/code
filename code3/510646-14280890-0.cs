    MemoryStream ms = new MemoryStream();
    XmlSerializer ourSerializer.Serialize(ms, xmlFile, ourXmlNamespaces);
    ms.Position = 0;
    //Encrypt the memorystream
    using (TextReader reader = new StreamReader(ms, Encoding.ASCII))
    using (StreamWriter writer = new StreamWriter(path))
    {
       string towrite = Encrypt(reader.ReadToEnd());
       writer.Write(towrite);
    }

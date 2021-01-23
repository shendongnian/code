    var myUrl = "http://www.stackoverflow.com";
    var encoding = Encoding.UTF8;
    XmlWriterSettings settings = new XmlWriterSettings();
    settings.Indent = true;
    settings.Encoding = encoding;
    var SOME_MAX_SIZE_IN_BYTES = 1024;
    MemoryStream ms = new MemoryStream();
    for(var i=0; i<10; i++)
    {
        using (XmlWriter writer = XmlWriter.Create(ms, settings))
        {    
            // CREATE XML WITH STATEMENTS LIKE THIS
            writer.WriteStartElement("url", myUrl);
            writer.WriteEndElement();
            // in order to get a semi-accurate byte count, 
            // you need to force the flush to the underlying stream
            writer.Flush();
            var lengthInBytes = ms.Length;
            if(lengthInBytes > SOME_MAX_SIZE_IN_BYTES)
            {
                Console.WriteLine("TOO BIG!");
                break;
            }
        }
    }
    
    var xml = encoding.GetString(ms.ToArray());
    Console.WriteLine(xml);

    //Its a NTemplate of TenPrint
    tenPrintTemplate.AddFingers(fingerPrintTemplate.Save());
    //start Proto Buffer serialization
    MemoryStream stream = new MemoryStream();
    int tenpritnTemplateSize = tenPrintTemplate.GetSize();
    NBuffer buffer = new NBuffer(tenpritnTemplateSize);
    // saving fingers template to buffer.
    tenPrintTemplate.Save(buffer);
    ProtoBuf.Serializer.Serialize<byte[]>(stream, buffer.ToArray());

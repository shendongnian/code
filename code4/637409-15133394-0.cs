    MemoryStream ms = new MemoryStream();
    _fileUpload.InputStream.CopyTo(ms);
    byte[] data = ms.ToArray();
    SendDummyEmail1(data);
    SendDummyEmail1(data);
    public static void SendDummyEmail1(byte[] fileContent)
    {
     ...
     var attachment = new Attachment(new MemoryStream(fileContent), ...
    }

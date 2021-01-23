    List<float> myNumbers = ...
    MemoryStream ms = new MemoryStream();
    using(BinaryWriter bw = new BinaryWriter(stream))
    {
        foreach(var n in myNumbers)
    	bw.Write(n);
    }
    ms.Seek(0, SeekOrigin.Begin);
    
    // Read the first 20 bytes from the stream.
    byteArray = new byte[ms.Length];
    count = memStream.Read(byteArray, 0, ms.Length);
    File.WriteAllBytes(path, byteArray);

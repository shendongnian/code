     using (var fileStream = File.OpenWrite(theFileName))
     using (var memoryStream = new MemoryStream())
     {
    // Serialize to memory instead of to file
    var formatter = new BinaryFormatter();
    formatter.Serialize(memoryStream, customer);
    // This resets the memory stream position for the following read operation
    memoryStream.Seek(0, SeekOrigin.Begin);
    // Get the bytes
    var bytes = new byte[memoryStream.Length];
    memoryStream.Read(bytes, 0, (int)memoryStream.Length);
    
    var encryptedBytes = yourCrypto.Encrypt(bytes);
    fileStream.Write(encryptedBytes, 0, encryptedBytes.Length);
    }

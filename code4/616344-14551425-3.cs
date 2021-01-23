    // Start of your code ...
    SymmetricAlgorithm rijn = SymmetricAlgorithm.Create();
    rijn.Mode = CipherMode.ECB;
    
    MemoryStream ms = new MemoryStream();
    byte[] rgbIV = Encoding.ASCII.GetBytes("PRIVATE");
    // Rest of your code ...

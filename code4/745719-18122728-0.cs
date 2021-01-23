    StringBuilder b = new StringBuilder();
    for (int i = 0; i < 8; i++)
    {
        b.Append(stringToConvert[i % stringToConvert.Length]);
    }
    stringToConvert = b.ToString();
    byte[] key = Encoding.Unicode.GetBytes(stringToConvert);//key size is 16 bytes = 128 bits

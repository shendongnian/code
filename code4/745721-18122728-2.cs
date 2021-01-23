    byte[] key = new byte[16];
    for (int i = 0; i < 16; i+=2)
    {
        byte[] unicodeBytes = BitConverter.GetBytes(stringToConvert[i % stringToConvert.Length]);
        Array.Copy(unicodeBytes, 0, key, i, 2);
    }

    string stringOfBytes = "88 00 1A 31 31 31";
    string[] stringBytes = stringOfBytes.Split(' ');
    byte[] outputBytes = new byte[stringBytes.Length];
    
    for (int i = 0; i < stringBytes.Length; i++)
    {
        outputBytes[i] = Convert.ToByte(stringBytes[i], 16);
    }

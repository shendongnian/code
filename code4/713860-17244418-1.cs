    static byte[] GetBytesFromHexString(string str)
    {
        byte[] bytes = new byte[str.Length * sizeof(byte)];
        for (var i = 0; i < str.Length; i++)
            bytes[i] = HexToInt(str[i]);
            return bytes;
    }
    static byte HexToInt(char hexChar)
    {
        hexChar = char.ToUpper(hexChar);  // may not be necessary
        return (byte)((int)hexChar < (int)'A' ?
            ((int)hexChar - (int)'0') :
            10 + ((int)hexChar - (int)'A'));
    }

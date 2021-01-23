    static byte HexToByte(string value, int offset)
    {
       string hex = value.Substring(offset, 2);
       return byte.Parse(hex, NumberStyles.HexNumber);
    }
    static short HexToSigned16(string value, bool isLittleEndian)
    {
       byte first = HexToByte(value, 0);
       byte second = HexToByte(value, 2);
       if (isLittleEndian) 
           return (short)(first | (second << 8));
       else
           return (short)(second | (first << 8));
    }
    ...
    string[] values = "AAFE B4FE B8FE".Split();
    foreach (string value in values)
    {
       Console.WriteLine("{0} == {1}", value, HexToSigned16(value, true));
    }

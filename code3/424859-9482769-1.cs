    public static string HexToBinary(string hexValue)
    {
        ulong number = UInt64.Parse(hexValue, System.Globalization.NumberStyles.HexNumber);
    
        byte[] bytes = BitConverter.GetBytes(number);
    
        string binaryString = string.Empty;
        foreach (byte singleByte in bytes)
        {
            binaryString += Convert.ToString(singleByte, 2);
        }
    
        return binaryString;
    }

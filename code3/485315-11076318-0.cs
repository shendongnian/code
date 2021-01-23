    private ICollection<byte> HexString2Ascii(string hexString)
    {
        var bytes = new List<byte>(hexString.Length / 2);
        for (int i = 0; i <= hexString.Length - 2; i += 2)
            bytes.Add(byte.Parse(hexString.Substring(i, 2), System.Globalization.NumberStyles.HexNumber));
        return bytes;
    }

    private Image Decode(string binary)
    {
        string input = binary;
        int numOfBytes = input.Length / 8;
        byte[] bytes = new byte[numOfBytes];
        for (int i = 0; i < numOfBytes; ++i)
        {
            bytes[i] = Convert.ToByte(input.Substring(8 * i, 8), 2);
        }
        MemoryStream FromBinary = new MemoryStream(bytes);
        return Image.FromStream(FromBinary);
    }

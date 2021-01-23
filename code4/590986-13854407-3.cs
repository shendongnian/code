    public string DecodeProductKey(byte[] digitalProductId)
    {
        // Possible alpha-numeric characters in product key.
        const string digits = "BCDFGHJKMPQRTVWXY2346789";
        // Length of decoded product key in byte-form. Each byte represents 2 chars.
        const int decodeStringLength = 15;
        // Decoded product key is of length 29
        char[] decodedChars = new char[29];
        // Extract encoded product key from bytes [52,67]
        List<byte> hexPid = new List<byte>();
        for (int i = 52; i <= 67; i++)
        {
            hexPid.Add(digitalProductId[i]);
        }
        // Decode characters
        for (int i = decodedChars.Length - 1; i >= 0; i--)
        {
            // Every sixth char is a separator.
            if ((i + 1) % 6 == 0)
            {
                decodedChars[i] = '-';
            }
            else
            {
                // Do the actual decoding.
                int digitMapIndex = 0;
                for (int j = decodeStringLength - 1; j >= 0; j--)
                {
                    int byteValue = (digitMapIndex << 8) | (byte)hexPid[j];
                    hexPid[j] = (byte)(byteValue / 24);
                    digitMapIndex = byteValue % 24;
                    decodedChars[i] = digits[digitMapIndex];
                }
            }
        }
        return new string(decodedChars);
    }

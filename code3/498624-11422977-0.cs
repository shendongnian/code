    string input = "8802000030000000C6020000330000000000008000000080000000000000000018000000";
    for (int i = 0; i < input.Length ; i += 8)
    {
        string subInput = input.Substring(i, 8);
        byte[] bytes = new byte[4];
        for (int j = 0; j < 4; ++j)
        {
            string toParse = subInput.Substring(j * 2, 2);
            bytes[j] = byte.Parse(toParse, NumberStyles.HexNumber);
        }
        uint num = BitConverter.ToUInt32(bytes, 0);
        Console.WriteLine(subInput + " --> " + num);
    }
    88020000 --> 648
    30000000 --> 48
    C6020000 --> 710
    33000000 --> 51
    00000080 --> 2147483648
    00000080 --> 2147483648
    00000000 --> 0
    00000000 --> 0
    18000000 --> 24

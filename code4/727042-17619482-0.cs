    Encoding cp437 = Encoding.GetEncoding(437);
    byte[] source = new byte[1];
    for (byte i = 0x20; i < 0xFE; i++)
    {
        source[0] = i;
        AnsiLookup.Add(i, cp437.GetString(source));
    }

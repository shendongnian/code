    static byte[] Demungify(byte[] value)
    {
        var result = new List<byte>(value.Length);
        bool xor = false;
        for (int i = 0; i < value.Length; i++)
        {
            byte b = value[i];
            if (xor)
            {
                b ^= 0x20;
                xor = false;
            }
            if (b == 0x7D)
            {
                xor = true; // xor the following byte
                continue; // skip this byte
            }
            result.Add(b);
        }
        return result.ToArray();
    }

    static byte[] ToBCD(DateTime d)
    {
        List<byte> bytes = new List<byte>();
        string s = d.ToString("yyyyMMddHHmm");
        for (int i = 0; i < s.Length; i+=2 )
        {
            bytes.Add((byte)((s[i] - '0') << 4 | (s[i+1] - '0')));
        }
        return bytes.ToArray();
    }

    var s = "0";
    var s1 = s.Aggregate("", (h, c) => h + $"{(int)c:x4}");     // left padded with 0       "0030d835dfcfd835dfdad835dfe5d835dff0d835dffb"
    var s2 = s.Aggregate("", (h, c) => h + $"{(int)c,4:x}");    // left padded with space   "  30d835dfcfd835dfdad835dfe5d835dff0d835dffb"
    var sL = BitConverter.ToString(Encoding.Unicode.GetBytes(s)).Replace("-", "");       // Little Endian "300035D8CFDF35D8DADF35D8E5DF35D8F0DF35D8FBDF"
    var sB = BitConverter.ToString(Encoding.BigEndianUnicode.GetBytes(s)).Replace("-", ""); // Big Endian "0030D835DFCFD835DFDAD835DFE5D835DFF0D835DFFB"
    // no encodding "300035D8CFDF35D8DADF35D8E5DF35D8F0DF35D8FBDF"
    byte[] b = new byte[s.Length * sizeof(char)];
    Buffer.BlockCopy(s.ToCharArray(), 0, b, 0, b.Length);
    var sb = BitConverter.ToString(b).Replace("-", "");

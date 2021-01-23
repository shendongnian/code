    //split the string
    string[] ranges = String.Split(':');
    ulong range0 = ulong.Parse (new string(from c in ranges[0] where char.IsDigit(c) select c))
    ulong range1 = .Parse (new string(from c in ranges[1] where char.IsDigit(c) select c))
    ranges[0] = new string(from c in ranges[0] where !char.IsDigit(c) select char)
    ranges[1] = new string(from c in ranges[1] where !char.IsDigit(c) select char)
    BigInteger unicodebytes0 = new BigInteger(Encoding.Unicode.GetBytes(ranges[0]), 0);
    BigInteger unicodebytes1 = new BigInteger(Encoding.Unicode.GetBytes(ranges[1]), 0);
    foreach (BigInteger i in LongRange(unicodebytes0, unicodebytes1)
    {
        foreach (ulong e in LongRange(range0, range1)
        {
            yield return Encoding.Unicode.GetString(i.ToByteArray()) + e.ToString()
        }
    }

    static readonly Dictionary<char, int> hexChars = "0123456789ABCDEF".ToDictionary(
        c => c,
        c => c >= 'A' ? c - 'A' + 10 : c - '0');
    static string HexToDecimal(string hex)
    {
        List<int> dec = new List<int>() { 0 };   // decimal result
        foreach (char c in hex)
        {
            int carry = hexChars[c];
            for (int i = 0; i < dec.Count; ++i)
            {
                int val = dec[i] * 16 + carry;
                dec[i] = val % 10;
                carry = val / 10;
            }
            while (carry > 0)
            {
                dec.Add(carry % 10);
                carry /= 10;
            }
        }
        var chars = dec.Select(d => (char)('0' + d));
        var cArr = chars.Reverse().ToArray();
        return new string(cArr);
    }

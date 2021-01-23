    static string HexToDecimal(string hex)
    {
        List<int> dec = new List<int>() { 0 };   // decimal result
        foreach (char c in hex)
        {
            int carry = Convert.ToInt32(c.ToString(), 16);
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

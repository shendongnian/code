    static string HexToDecimal(string hex)
    {
        hex = new string(hex.Reverse().ToArray());  // arrays are easier to work with
                                                    // if we treat them as little-endian
        List<int> pos = new List<int>() { 1 };   // positional value
        List<int> dec = new List<int>() { 0 };   // decimal result
        for (int i = 0; i < hex.Length; ++i)
        {
            char c = hex[i];   // current hex character being processed 
                               // (starting from least significant)
            for (int j = 0; j < pos.Count; ++j)
                dec[j] += hexChar[c] * pos[j];
            for (int j = 0; j < pos.Count; ++j)
                pos[j] *= 16;
            Flatten(dec);
            Flatten(pos);
            while (dec.Count < pos.Count)
                dec.Add(0);
        }
        char[] chars = dec.Select(d => (char)('0' + d)).Reverse().ToArray();
        string result = new string(chars);
        return result.TrimStart('0');
    }
    static void Flatten(List<int> ints)
    {
        int carry = 0;
        for (int i = 0; i < ints.Count; ++i)
        {
            int curr = ints[i] + carry;
            ints[i] = curr % 10;
            carry = curr / 10;
        }
        while (carry > 0)
        {
            ints.Add(carry % 10);
            carry /= 10;
        }
    }
    static readonly Dictionary<char, int> hexChar = 
        Enumerable.Range(0, 16).ToDictionary(b => b.ToString("X").Single());

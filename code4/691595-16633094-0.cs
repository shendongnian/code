    string ToLatinDigits(string nativeDigits)
    {
        int n = nativeDigits.Length;
        StringBuilder latinDigits = new StringBuilder(capacity: n);
        for (int i = 0; i < n; ++i)
        {
            if (!char.IsDigit(nativeDigits, i)) throw new ArgumentOutOfRangeException("nativeDigits");
            latinDigits.Append(char.GetNumericValue(nativeDigits, i));
        }
        return latinDigits;
    }
    var number = int.Parse(ToLatinDigits("४५"));

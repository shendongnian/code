    public decimal FromBinaryString(string binary)
    {
        if (binary == null)
            throw new ArgumentNullException();
        if (!binary.All(c => c == '0' || c == '1'))
            throw new InvalidOperationException();
        decimal result = 0;
        foreach (var c in binary)
        {
            result *= 2;
            result += (c - '0');
        }
        return result;
    }

    public BigInteger FromBinaryString(string binary)
    {
        if (binary == null)
            throw new ArgumentNullException();
        if (!binary.All(c => c == '0' || c == '1'))
            throw new InvalidOperationException();
    
        BigInteger result = 0;
        foreach (var c in binary)
        {
            result <<= 1;
            result += (c - '0');
        }
        return result;
    }

    private readonly Dictionary<char, int> values
        = digits.ToDictionary(c => c, c => digits.IndexOf(c));
    public BigInteger ParseBigInteger(string value, int baseOfValue)
    {
        return value.Aggregate(
            new BigInteger,
            (current, digit) => current * baseOfValue + values[digit]);
    }

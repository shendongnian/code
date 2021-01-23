    private const string digits = "0123456789ABCDEF";
    private readonly Dictionary<char, BigInteger> values
        = digits.ToDictionary(c => c, c => (BigInteger)digits.IndexOf(c));
    public BigInteger ParseBigInteger(string value, BigInteger baseOfValue)
    {
        return value.Aggregate(
            new BigInteger,
            (current, digit) => current * baseOfValue + values[digit]);
    }

    private Dictionary<T, string[]> Value;
    public BaseComparer()
    {
        Value = new Dictionary<T, string[]>();
    }
    string[] strFirst, strSecond;
    if (! Value.TryGetValue(lhs, out strFirst))
    {                
        strFirst = Regex.Split(lhs.ToString().Replace(" ", ""), "([0-9]+)");
        strFirst = Regex.Split(lhs.ToString().Replace("|", ">>"), "([0-9]+)");
        Value.Add(lhs, strFirst);
    }
    if (! Value.TryGetValue(rhs, out strSecond))
    {
        strSecond = Regex.Split(rhs.ToString().Replace(" ", ""), "([0-9]+)");
        strSecond = Regex.Split(rhs.ToString().Replace("|", ">>"), "([0-9]+)");
        Value.Add(rhs, strSecond);
    }

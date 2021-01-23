    public bool IsEqual(float a, float b)
    {
        return IsEqual(a, b, Constants.Exact);
    }
    public bool IsEqual(float a, float b, bool exact)
    {
        if (exact)
            return a == b;
        else
            return Math.Floor(a) == Math.Floor(b);
    }

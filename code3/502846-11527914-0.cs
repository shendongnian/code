    public int GetHashCode(bool[] x)
    {
        int result = 29;
        foreach (bool b in x)
        {
            if (b) { result++; }
            result *= 23;
        }
        return result;
    }

    public int IntFromString(string str)
    {
        int result = 0;
        foreach (char c in str)
        {
            if (!char.IsDigit(c))
            {
                break;
            }
            result = result * 10 + c - '0';
        }
        return result;
    }

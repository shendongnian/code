    public int EatWhitespace(string input, int pos)
    {
        while(Char.IsWhiteSpace(input[pos])
            ++pos;
        return pos;
    }

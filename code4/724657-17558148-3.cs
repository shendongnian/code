    public bool TryParse(string s, out int result)
    {
        result = 0;
        try
        {
            result = Int32.Parse(s);
            return true; // parsing succeed
        }
        catch(FormatException)
        {
            return false; // parsing failed, you don't care of result value
        }
    }

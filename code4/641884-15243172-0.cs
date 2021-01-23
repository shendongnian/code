    private string ChangeFor(string input, IEnumerable<char> before, char after)
    {
        string result = input;
        foreach (char c in before)
        {
            result = result.Replace(c, after);
        }
        return result;
    }

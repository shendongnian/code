    public string GetResultsWithHyphen(string input)
    {
        // append hyphen after 4 characters logic goes here
        string output = "";
        int start = 0;
        while (start < input.Length)
        {
            output += input.Substring(start, 4);
            start += 4;
        }
        return output;
    }

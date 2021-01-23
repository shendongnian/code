    public string GetResultsWithHyphen(string input)
    {
        // append hyphen after 4 characters logic goes here
        string output = "";
        int start = 0;
        while (start < input.Length)
        {
            output += input.Substring(start, Math.Min(4,input.Length - start)) + "-";
            start += 4;
        }
        // remove the trailing dash
        return output.Trim('-');
    }

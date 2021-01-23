    public List<string> SplitAtPositions(string input, List<int> delimiterPositions)
    {
        var output = new List<string>();
        for (int i = 0; i < delimiterPositions.Count; i++)
        {
            int index = i == 0 ? 0 : delimiterPositions[i - 1] + 1;
            int length = delimiterPositions[i] - index;
            string s = input.Substring(index, length);
            output.Add(s);
        }
        string lastString = input.Substring(delimiterPositions.Last() + 1);
        output.Add(lastString);
        return output;
    }

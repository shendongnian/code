    public bool CheckIfAllcharactersInARowAreTheSame (string line, char c)
    {
        string tempLine = line.replace(c, '');
        return (tempLine.Length == 0);
    }

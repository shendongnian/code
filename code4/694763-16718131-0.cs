    IEnumerable<string> UnindentAsMuchAsPossible(string[] content)
    {
        int spacesOnFirstLine = content[0].TakeWhile(c => c == ' ').Count();
        return content.Select(line => line.Substring(spacesOnFirstLine));
    }

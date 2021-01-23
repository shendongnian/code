    /// <summary>
    /// Given a cell name, parses the specified cell to get the column name.
    /// </summary>
    /// <param name="cellReference">Address of the cell (ie. B2)</param>
    /// <returns>Column name (ie. A2)</returns>
    private static string GetColumnName(string cellName)
    {
        // Create a regular expression to match the column name portion of the cell name.
        Regex regex = new Regex("[A-Za-z]+");
        Match match = regex.Match(cellName);
    
        return match.Value;
    }
    public enum CellReferencePartEnum
    {
        None,
        Column,
        Row,
        Both
    }
        private static List<char> Letters = new List<char>() { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', ' ' };

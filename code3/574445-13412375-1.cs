    private static string GetColumnName(string cellReference)
    {
    	if (ColumnNameRegex.IsMatch(cellReference))
    		return ColumnNameRegex.Match(cellReference).Value;
    
    	throw new ArgumentOutOfRangeException(cellReference);
    }
    
    private static readonly Regex ColumnNameRegex = new Regex("[A-Za-z]+");

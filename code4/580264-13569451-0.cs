    /// <summary>
    /// Remove characters from string
    /// </summary>
    public static string RemoveSpecialCharacters(string text, bool allowSpace)
    {
    	var normalizedString = text;
    
    	// Prepare the symbol table.
    	var symbolTable = new Dictionary<char, char[]>();
    
    	symbolTable.Add('a', new char[] { 'à', 'á', 'ä', 'â', 'ã' });
    	symbolTable.Add('c', new char[] { 'ç' });
    	symbolTable.Add('e', new char[] { 'è', 'é', 'ë', 'ê' });
    	symbolTable.Add('i', new char[] { 'ì', 'í', 'ï', 'î' });
    	symbolTable.Add('o', new char[] { 'ò', 'ó', 'ö', 'ô', 'õ' });
    	symbolTable.Add('u', new char[] { 'ù', 'ú', 'ü', 'û' });
    
    	// Replaces the symbols.
    	foreach (var key in symbolTable.Keys)
    	{
    		foreach (var symbol in symbolTable[key])
    		{
    			normalizedString = normalizedString.Replace(symbol, key);
    		}
    	}
    
    	// Remove the other special characters.
    	if (allowSpace)
    		normalizedString = System.Text.RegularExpressions.Regex.Replace(normalizedString, @"[^0-9a-zA-Z.-_\s]+?", string.Empty);
    	else
    		normalizedString = System.Text.RegularExpressions.Regex.Replace(normalizedString, @"[^0-9a-zA-Z.-_]+?", string.Empty);
    
    	return normalizedString;
    }

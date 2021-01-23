    private void Test()
    {
    	string regex = "style=background:url\\(\'(?<bgpath>.*)\'\\)";
    	System.Text.RegularExpressions.RegexOptions options = ((System.Text.RegularExpressions.RegexOptions.IgnorePatternWhitespace | System.Text.RegularExpressions.RegexOptions.Multiline) 
    				| System.Text.RegularExpressions.RegexOptions.IgnoreCase);
    	System.Text.RegularExpressions.Regex reg = new System.Text.RegularExpressions.Regex(regex, options);
    }

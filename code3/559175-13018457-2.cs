    public override string ToString()
    {
        char[] openingBracket = new char[] { '[' };
        char[] closingBracket = new char[] { ']' };     
          
        string trimmedBaseString = (base.ToString() ?? string.Empty)
                                   .TrimStart(openingBracket).TrimEnd(closingBracket);
        return string.Format("[{0} PointTerm: {1};]", trimmedBaseString, PointTerm);
    }

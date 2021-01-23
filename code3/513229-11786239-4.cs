    public static bool TestStringFromShortStrings(string checkText, string[] pieces) {
        // Build the expression.  Ultimate result will be
        // of the form "^(xxx|yyy|zzz)+$".
        var expr = "^(" + 
                   String.Join("|", pieces.Select(Regex.Escape)) + 
                   ")+$";
        
        // Check whether the supplied string matches the expression.
        return Regex.IsMatch(checkText, expr);
    }

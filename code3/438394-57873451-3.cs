    private static System.Text.RegularExpressions.Regex everythingExceptNewLines = 
        new System.Text.RegularExpressions.Regex("[^\r\n]");
    // http://drizin.io/Removing-comments-from-SQL-scripts/
    // http://web.archive.org/web/*/http://drizin.io/Removing-comments-from-SQL-scripts/
    public static string RemoveComments(string input, bool preservePositions, bool removeLiterals = false)
    {
        //based on http://stackoverflow.com/questions/3524317/regex-to-strip-line-comments-from-c-sharp/3524689#3524689
        var lineComments = @"--(.*?)\r?\n";
        var lineCommentsOnLastLine = @"--(.*?)$"; // because it's possible that there's no \r\n after the last line comment
                                                  // literals ('literals'), bracketedIdentifiers ([object]) and quotedIdentifiers ("object"), they follow the same structure:
                                                  // there's the start character, any consecutive pairs of closing characters are considered part of the literal/identifier, and then comes the closing character
        var literals = @"('(('')|[^'])*')"; // 'John', 'O''malley''s', etc
        var bracketedIdentifiers = @"\[((\]\])|[^\]])* \]"; // [object], [ % object]] ], etc
        var quotedIdentifiers = @"(\""((\""\"")|[^""])*\"")"; // "object", "object[]", etc - when QUOTED_IDENTIFIER is set to ON, they are identifiers, else they are literals
                                                              //var blockComments = @"/\*(.*?)\*/";  //the original code was for C#, but Microsoft SQL allows a nested block comments // //https://msdn.microsoft.com/en-us/library/ms178623.aspx
        //so we should use balancing groups // http://weblogs.asp.net/whaggard/377025
        var nestedBlockComments = @"/\*
                             (?>
                             /\*  (?<LEVEL>)      # On opening push level
                             | 
                             \*/ (?<-LEVEL>)     # On closing pop level
                             |
                             (?! /\* | \*/ ) . # Match any char unless the opening and closing strings   
                             )+                         # /* or */ in the lookahead string
                             (?(LEVEL)(?!))             # If level exists then fail
                             \*/";
        string noComments = System.Text.RegularExpressions.Regex.Replace(input,
            nestedBlockComments + "|" + lineComments + "|" + lineCommentsOnLastLine + "|" + literals + "|" + bracketedIdentifiers + "|" + quotedIdentifiers,
            me => {
                if (me.Value.StartsWith("/*") && preservePositions)
                    return everythingExceptNewLines.Replace(me.Value, " "); // preserve positions and keep line-breaks // return new string(' ', me.Value.Length);
         else if (me.Value.StartsWith("/*") && !preservePositions)
                    return "";
                else if (me.Value.StartsWith("--") && preservePositions)
                    return everythingExceptNewLines.Replace(me.Value, " "); // preserve positions and keep line-breaks
         else if (me.Value.StartsWith("--") && !preservePositions)
                    return everythingExceptNewLines.Replace(me.Value, ""); // preserve only line-breaks // Environment.NewLine;
         else if (me.Value.StartsWith("[") || me.Value.StartsWith("\""))
                    return me.Value; // do not remove object identifiers ever
         else if (!removeLiterals) // Keep the literal strings
             return me.Value;
                else if (removeLiterals && preservePositions) // remove literals, but preserving positions and line-breaks
         {
                    var literalWithLineBreaks = everythingExceptNewLines.Replace(me.Value, " ");
                    return "'" + literalWithLineBreaks.Substring(1, literalWithLineBreaks.Length - 2) + "'";
                }
                else if (removeLiterals && !preservePositions) // wrap completely all literals
             return "''";
                else
                    throw new System.NotImplementedException();
            },
            System.Text.RegularExpressions.RegexOptions.Singleline | System.Text.RegularExpressions.RegexOptions.IgnorePatternWhitespace);
        return noComments;
    }

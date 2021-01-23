    // https://michaeljswart.com/2014/04/removing-comments-from-sql/
    // http://web.archive.org/web/*/https://michaeljswart.com/2014/04/removing-comments-from-sql/
    public static string StripCommentsFromSQL(string SQL)
    {
        Microsoft.SqlServer.TransactSql.ScriptDom.TSql150Parser parser = 
            new Microsoft.SqlServer.TransactSql.ScriptDom.TSql150Parser(true);
        System.Collections.Generic.IList<Microsoft.SqlServer.TransactSql.ScriptDom.ParseError> errors;
        Microsoft.SqlServer.TransactSql.ScriptDom.TSqlFragment fragments = 
            parser.Parse(new System.IO.StringReader(SQL), out errors);
        // clear comments
        string result = string.Join(
          string.Empty,
          fragments.ScriptTokenStream
              .Where(x => x.TokenType != Microsoft.SqlServer.TransactSql.ScriptDom.TSqlTokenType.MultilineComment)
              .Where(x => x.TokenType != Microsoft.SqlServer.TransactSql.ScriptDom.TSqlTokenType.SingleLineComment)
              .Select(x => x.Text));
        return result;
    }

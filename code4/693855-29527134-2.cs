    public class Parser
    {
        public static List<string> GetTableNamesFromQueryString(string query)
        {
            var output = new List<string>();
            var sb = new StringBuilder();
            var parser = new TSql120Parser(true);
            
            var fromTokenTypes = new[]
            {
                TSqlTokenType.From,
                TSqlTokenType.Join
            };
            var identifierTokenTypes = new[]
            {
                TSqlTokenType.Identifier,
                TSqlTokenType.QuotedIdentifier
            };
            using (System.IO.TextReader tReader = new System.IO.StringReader(query))
            {
                IList<ParseError> errors;
                var queryTokens = parser.GetTokenStream(tReader, out errors);
                if (errors.Any())
                {
                    return errors
                        .Select(e => string.Format("Error: {0}; Line: {1}; Column: {2}; Offset: {3};  Message: {4};", e.Number, e.Line, e.Column, e.Offset, e.Message))
                        .ToList();
                }
                for (var i = 0; i < queryTokens.Count; i++)
                {
                    if (fromTokenTypes.Contains(queryTokens[i].TokenType))
                    {
                        for (var j = i + 1; j < queryTokens.Count; j++)
                        {
                            if (queryTokens[j].TokenType == TSqlTokenType.WhiteSpace)
                            {
                                continue;
                            }
                            if (identifierTokenTypes.Contains(queryTokens[j].TokenType))
                            {
                                sb.Clear();
                                GetQuotedIdentifier(queryTokens[j], sb);
                                while (j + 2 < queryTokens.Count 
                                    && queryTokens[j + 1].TokenType == TSqlTokenType.Dot 
                                    && (queryTokens[j + 2].TokenType == TSqlTokenType.Dot || identifierTokenTypes.Contains(queryTokens[j + 2].TokenType)))
                                {
                                    sb.Append(queryTokens[j + 1].Text);
                                    if (queryTokens[j + 2].TokenType == TSqlTokenType.Dot)
                                    {
                                        if (queryTokens[j - 1].TokenType == TSqlTokenType.Dot) 
                                            GetQuotedIdentifier(queryTokens[j + 1], sb);
                                        j++;
                                    }
                                    else
                                    {
                                        GetQuotedIdentifier(queryTokens[j + 2], sb);
                                        j += 2;
                                    }
                                }
                                output.Add(sb.ToString());
                            }
                            break;
                        }
                    }
                }
                return output.Distinct().OrderBy(tableName => tableName).ToList();
            }
        }
        private static void GetQuotedIdentifier(TSqlParserToken token, StringBuilder sb)
        {
            switch (token.TokenType)
            {
                case TSqlTokenType.Identifier: 
                    sb.Append('[').Append(token.Text).Append(']'); 
                    break;
                case TSqlTokenType.QuotedIdentifier:
                case TSqlTokenType.Dot: 
                    sb.Append(token.Text); 
                    break;
                    
                default: throw new ArgumentException("Error: expected TokenType of token should be TSqlTokenType.Dot, TSqlTokenType.Identifier, or TSqlTokenType.QuotedIdentifier");
            }
        }
    }

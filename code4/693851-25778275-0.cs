	private List<string> GetTableNamesFromQueryString(string query)
	{
		IList<ParseError> errors = new List<ParseError>();
		IList<TSqlParserToken> queryTokens;
		List<string> output = new List<string>(16);
		StringBuilder sb = new StringBuilder(128);
		TSql120Parser parser = new TSql120Parser(true);
		TSqlTokenType[] fromTokenTypes = new TSqlTokenType[2]
			{
				TSqlTokenType.From,
				TSqlTokenType.Join
			};
		TSqlTokenType[] identifierTokenTypes = new TSqlTokenType[2]
			{
				TSqlTokenType.Identifier,
				TSqlTokenType.QuotedIdentifier
			};
		using (System.IO.TextReader tReader = new System.IO.StringReader(query))
		{
			queryTokens = parser.GetTokenStream(tReader, out errors);
			if (errors.Count > 0) { return errors.Select(e=>"Error: " + e.Number + " Line: " + e.Line + " Column: " + e.Column + " Offset: " + e.Offset + " Message: " + e.Message).ToList(); }
			for (int i = 0; i < queryTokens.Count; i++)
			{
				if(fromTokenTypes.Contains(queryTokens[i].TokenType))
				{
					for (int j = i + 1; j < queryTokens.Count; j++)
					{
						if (queryTokens[j].TokenType == TSqlTokenType.WhiteSpace) { continue; }
						else if (identifierTokenTypes.Contains(queryTokens[j].TokenType))
						{
							sb.Clear();
							GetQuotedIdentifier(queryTokens[j], sb);			//Change Identifiers to QuotedIdentifier (text only)
							while (j + 2 < queryTokens.Count && queryTokens[j + 1].TokenType == TSqlTokenType.Dot && identifierTokenTypes.Contains(queryTokens[j + 2].TokenType))
							{
								sb.Append(queryTokens[j + 1].Text);
								GetQuotedIdentifier(queryTokens[j + 2], sb);	//Change Identifiers to QuotedIdentifier (text only)
								j += 2;
							}
							output.Add(sb.ToString());
							break;				//exit the loop
						}
						else { break; }				//exit the loop if token is not a FROM, a JOIN, or white space.
					}
				}
			}
			return output.Distinct().OrderBy(tableName => tableName).ToList();
		}
	}
	private void GetQuotedIdentifier(TSqlParserToken token, StringBuilder sb)
	{
		switch(token.TokenType)
		{
			case TSqlTokenType.Identifier: sb.Append('[').Append(token.Text).Append(']'); return;
			case TSqlTokenType.QuotedIdentifier: sb.Append(token.Text); return;
			default: throw new ArgumentException("Error: expected TokenType of token should be TSqlTokenType.Identifier or TSqlTokenType.QuotedIdentifier");
		}
	}

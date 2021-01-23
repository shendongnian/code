	private static ArrayList GetUsedTablesFromQuery(string strQuery)
	{
		var parser = new TSql100Parser(true);
		IList<ParseError> errors = new List<ParseError>();
		using (TextReader r = new StringReader(strQuery))
		{
			var result = parser.GetTokenStream(r, out errors);
			var tables = result
				.Select((i, index) => (i.TokenType == TSqlTokenType.From) ? result[index + 2].Text : null)
				.Where(i => i != null)
				.ToArray();
			return new ArrayList(tables);
		}
	}

	var tokensWithValues = new Dictionary<string, object>()
	{
		{"[@date]", DateTime.Now},
		{"[@time]", DateTime.Now.Ticks},
		{"[@fileName]", "myFile.xml"},
	};
	
	var sqlQuery = File.ReadAllText("mysql.sql");
		
	foreach (var tokenValue in tokensWithValues)
	{
		sqlQuery = sqlQuery.Replace(tokenValue.Key, tokenValue.Value.ToString());
	}

	public string GenerateSQL(T tree) {
		var valueSets = ExplodeValueSets(tree);
		var sql = new StringBuilder();
		foreach (var set in valueSets)
			sql.AppendLine(GenerateSingleSQLInsert(tree, set));
		var finalSql = sql.ToString();
		return finalSql;
	}
	
    public string GenerateSingleSQLInsert(T tree, List<string> values) {
        var sqlFormat = "insert into [{0}]([{1}]) values('{2}');";
		var table = tree.tableName;
		var columnList = string.Join("],[", tree.column.Select (c => c.className).ToArray());
		var valueList = string.Join("','", values.ToArray());
		var sql = string.Format(sqlFormat, table, columnList, valueList);
		return sql;
    }

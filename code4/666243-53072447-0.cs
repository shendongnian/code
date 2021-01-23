	private IEnumerable<string> GetTrackedTableNames(IOrmLiteDialectProvider dialectProvider)
	{
	    var method = typeof(SqlExpressionExtensions).GetMethod(nameof(SqlExpressionExtensions.Table), new[] { typeof(IOrmLiteDialectProvider) });
	    if (method == null)
	    {
	        throw new MissingMethodException(nameof(SqlExpressionExtensions), nameof(SqlExpressionExtensions.Table));
	    }
	    foreach (var table in _trackChangesOnTables)
	    {
	        if (method.MakeGenericMethod(table).Invoke(null, new object[] { dialectProvider }) is string tableName)
	        {
	            yield return tableName;
	        }
	    }
	}

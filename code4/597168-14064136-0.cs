    public virtual int? Insert(dynamic data)
    {
    	var o = (object)data;
    	List<string> paramNames = GetParamNames(o);
    
    	string cols = string.Join(",", paramNames);
    	string cols_params = string.Join(",", paramNames.Select(p => "@" + p));
    	var sql = "set nocount on insert " + TableName + " (" + cols + ") values (" + cols_params + ") select cast(scope_identity() as int)";
    
    	return database.Query<int?>(sql, o).Single();
    }

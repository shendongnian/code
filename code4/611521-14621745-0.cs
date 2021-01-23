	public virtual DataTable GetTables(string catalog, string schemaPattern, string 
    tableNamePattern, string[] types){
    var restrictions = new[] { catalog, schemaPattern, tableNamePattern }; 
    return connection.GetSchema("Tables", restrictions);\
    }

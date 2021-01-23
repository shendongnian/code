    var dialect = Dialect.GetDialect(properties);
    var table = new Table();
    // add columns
    
    var sql = table.GetSqlCreatestring(dialect);
    
    using (var sf = emptyConfig.BuildSessionfactory())
    {
        session.CreateSqlQuery(sql).ExecuteUpdate();
    }

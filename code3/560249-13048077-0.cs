    var p = new DynamicParameters(); 
    p.Add("@id", id); 
    p.Add("TotalRows", dbType: DbType.Int32, direction: ParameterDirection.Output); 
    
    using (var multi = cnn.QueryMultiple(string.Format("dbo.[{0}]", spName), p,
        commandType: CommandType.StoredProcedure))
    {      
        var results = multi.Read<New_Supplier>().ToList<IDBSupplier>();
        var areas = multi.Read<node>().ToList<IDBNode>();
        var categories = multi.Read<node>().ToList<IDBNode>();
    }
    int TotalRows = p.Get<int>("@TotalRows");

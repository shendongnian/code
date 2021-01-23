    downloadOnlyScopeDesc.Tables.Add(SqlSyncDescriptionBuilder.GetDescriptionForTable("aspnet_Users", (System.Data.SqlClient.SqlConnection)provider.Connection));
    
    //untag wrong PK information
    foreach(var pkColumn in downloadOnlyScopeDesc.Tables["aspnet_Users"].PkColumns)
    {
        downloadOnlyScopeDesc.Tables["aspnet_Users"].Columns[pkColumn.QuotedName].IsPrimaryKey = false;
    }
    
    //tag the correct PK
    downloadOnlyScopeDesc.Tables["aspnet_Users"].Columns["UserId"].IsPrimaryKey = true;

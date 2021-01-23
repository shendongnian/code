        string query = "insert into ACTIVE.dbo.Workspaces_WsToRefile values(@folderID, @newWorkSpace, @createDate)";
    
    using(SqlCommand cmd = new SqlCommand(query, SqlConnection))
    {
    	
    	SqlParameter param = new SqlParameter("@folderID", folderId);
    	param.SqlDbType = SqlDbType.Int;
    	cmd.Parameters.Add(param);
    	.....
    }

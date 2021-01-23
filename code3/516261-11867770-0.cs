        string query = "insert into ACTIVE.dbo.Workspaces_WsToRefile values(@folderID, @newWorkSpace,getdate())";
    
    using(SqlCommand cmd = new SqlCommand(query, SqlConnection))
    {
    	
    	SqlParameter param = new SqlParameter("@folderID", folderId);
    	param.SqlDataType = SqlDataType.Int;
    	cmd.Parameters.Add(param);
    	.....
    }

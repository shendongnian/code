    SqlCommand myCommand = new SqlCommand("insert into ACTIVE.dbo.Workspaces_WsToRefile" + 
                                          " values(@id, @space, getDate()", myConnection);  
    myCommand.Parameters.AddWithValue("@id", folderId);
    myCommand.Parameters.AddWithValue("@space", NewWorkspaceName);
    myCommand.ExecuteNonQuery();

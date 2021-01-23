    SqlConnection sqlCon = new SqlConnection("context connection=true"));
    sqlCon.Open();
    
    try {
    	SqlCommand sqlCommand = new SqlCommand(String.Format("raiserror('{0}', 0, 0) with nowait", str), sqlCon);
    	SqlContext.Pipe.ExecuteAndSend(sqlCommand);
    } finally {
    	sqlCon.Close();
    }

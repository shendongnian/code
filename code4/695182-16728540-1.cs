    List<string> lstSQLConStr = new List<string>();
    lstSQLConStr.Add(@"Server=myServerAddress1;Database=myDataBase;User Id=myUsername;Password=myPassword;");
    lstSQLConStr.Add(@"Server=myServerAddress2;Database=myDataBase;User Id=myUsername;Password=myPassword;");
    lstSQLConStr.Add(@"Server=myServerAddress3;Database=myDataBase;User Id=myUsername;Password=myPassword;");
    lstSQLConStr.Add(@"Server=myServerAddress4;Database=myDataBase;User Id=myUsername;Password=myPassword;");
    
    string cmd = "SELECT * FROM BOOKS1 UNION SELECT * FROM BOOKS2 UNION SELECT * FROM BOOKS3";
    
    SqlConnection sqlCon = null;
    SqlCommand sqlCmd = null;
    
    DataTable dtResult = new DataTable();
    
    for (int i = 0; i < lstSQLConStr.Count; i++)
    {
    	using (sqlCon = new SqlConnection(lstSQLConStr[i]))
    	{
    		sqlCon.Open();
    
    		using (sqlCmd = new SqlCommand(cmd, sqlCon))
    		{
    			sqlCmd.CommandType = CommandType.Text;
    
    			using (SqlDataReader dataReader = sqlCmd.ExecuteReader())
    			{
    				dtResult.Load(dataReader);
    			}
    		}
    	}
    }
    
    //here dtResult contains all results.

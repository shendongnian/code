    DataTable dt = dataTimesheet.DataSource as DataTable;
    string sqlText = "SELECT * FROM tblCaseTypes;"; 
    string conStr = cConnectionString.BuildConnectionString(); 
    SqlConnection linkToDB = new SqlConnection(conStr); 
    SqlDataAdapter myAdapter = new SqlDataAdapter(); 
    myAdapter.SelectCommand = new SqlCommand(sqlText, linkToDB);
    myAdapter.Update(dt); 

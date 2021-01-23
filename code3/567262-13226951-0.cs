    private string GetConnection()
     {
         return "DRIVER={MySQL ODBC 3.51 Driver};Server=localhost;Database=testdatabase";
     }
    
        private void LoadUsers()
        {
        
         DataTable rt = new DataTable();
         DataSet ds = new DataSet();
         OdbcDataAdapter da = new OdbcDataAdapter();
         OdbcConnection con = new OdbcConnection(GetConnection());
         OdbcCommand cmd = new OdbcCommand(sql, con);
         da.SelectCommand = cmd;
         da.Fill(ds);         
         rt = ds.Tables[0];
        
                           
          DeleteUsersList.DataSource = rt;
          DeleteUsersList.DataTextField = "UserName";
          DeleteUsersList.DataValueField = "UserID";
          DeleteUsersList.DataBind();
                    
         }
       

    String connString ="Data Source=localhost;User ID=username;Password=passwrd;";
            using (SqlConnection sqlConn = new SqlConnection(connString))
            {
                sqlConn.Open();
                DataTable tblDatabases = sqlConn.GetSchema("Databases");
                sqlConn.Close();
                DataTable td = tblDatabases.Select("dbid>6").CopyToDataTable();
             }

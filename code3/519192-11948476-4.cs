    List<string> file = GetImagesFromServerFolder();  
    foreach (var s in file)  
    {  
            const string connStr = "INSERT INTO tblPdfLocations (location) VALUES (@location)";
            //Store the connection details as a string
        string connstr =
            String.Format(@"SERVER=[LOCATION]; UID=[USERNAME]; pwd=[PASSWORD]; Database=[DATABASE]");
        //Initialise the connection to the server using the connection string.
        _sqlConn = new SqlConnection(connstr);
            var sqlComm = new SqlCommand(connStr, _sqlConn) {CommandType = CommandType.Text};
            sqlComm.Parameters.Add(new SqlParameter("@location", SqlDbType.VarChar, 50)).Value = s;
            sqlComm.ExecuteNonQuery();
            _sqlConn.Close();
    }

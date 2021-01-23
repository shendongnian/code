    try
    {
        string MyConString =
            "SERVER=localhost;" +
            "DATABASE=permdata;" +
            "UID=user;" +
            "PASSWORD=pass;";
        DataSet dataSet = new DataSet(); // Set a new DataSet instance
        string sql = "SELECT expDate, user, sfolder FROM  permuser WHERE expDate=GetDate()"
    
        MySqlConnection connection = new MySqlConnection(MyConString);
        MySqlCommand cmdSel = new MySqlCommand(sql, connection);
        new SqlDataAdapter(cmdSel).Fill(dataSet, "permuser"); // passing the command into the DataAdapter
        
    
        foreach (DataRow row in dataSet.Tables["permuser"].Rows)
            {
                //*get user and share path
                row["user"]; //User rows
                 row["sfolder"]; //sfolder rows
                *myDirectorySecurity.RemoveAccessRule (user/share path)
            }
    
        connection.Close();
        connection.Dispose();
    }
    
    catch (MySqlException ex)
    {
        MessageBox.Show(ex.Message);
        Close();
    }

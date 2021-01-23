    string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source="+FileToConvert+";Extended Properties=Excel 8.0;";
    try
    {
        OleDbConnection connection = new OleDbConnection(connectionString);
        connection.Open();
        //this next line assumes that the file is in default Excel format with Sheet1 as the first sheet name, adjust accordingly
        OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM [Sheet1$]", connection);
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        adapter.Fill(ds);//now you have your dataset ds now filled with the data and ready for manipulation
        // do stuff
    }

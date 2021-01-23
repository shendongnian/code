    var ef = new EFContext();
    var sqlConn = ef.Database.Connection as SqlConnection;
    var cmd = new SqlCommand("sp_spaceused")
    {
        CommandType = System.Data.CommandType.StoredProcedure,
        Connection = sqlConn as SqlConnection
    };
    var adp = new SqlDataAdapter(cmd);
    var dataset = new DataSet();
    sqlConn.Open();
    adp.Fill(dataset);
    sqlConn.Close();
    //You will get:
    //database_name	database_size	unallocated space
    //performance	    1091.00 MB	    456.00 MB
    //
    //reserved	data	    index_size	unused
    //557056 KB	540680 KB	10472 KB	5904 KB
    Console.WriteLine(dataset.Tables[0].Rows[0][1]);

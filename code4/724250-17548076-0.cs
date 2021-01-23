    SqlConnection connex = new SqlConnection();
    connex.ConnnectionString = "connection string to data";
    try
    {
        //connect to the database
        connex.Open();
        //set the select command to be used for pulling in info
        da.SelectCommand.Connection = connex;
        //fill the dbData object with data from the database
        da.Fill(dt);
        //close database connection
        connex.Close();
    }
    catch (Exception ex) { }

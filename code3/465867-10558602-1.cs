     SqlConnection con = new SqlConnection("your connection string");
        SqlCommand com = new SqlCommand();
        com.CommandType = CommandType.StoredProcedure;
        com.Connection = con;
        com.CommandText = "yourstoredprocedurename"; //no paranthesis or call key word just procedure name
        SqlParameter parameter = new SqlParameter("yourparametername", SqlDbType.Binary); //just parameter name no questionmark
        parameter.Direction= ParameterDirection.Output;
        com.Parameters.Add(parameter);
        con.Open();
        var df = com.ExecuteReader(CommandBehavior.SingleResult);
        //some stuff
        con.Close();

    private DataSet ExecuteDataSet(string storedProcName, SqlParameter[] parameters)
    {
        SqlCommand command = new SqlCommand();
        command.CommandText = storedProcName;
        command.Parameters.AddRange(parameters);
        command.CommandType = CommandType.StoredProcedure;
        command.Connection = (SqlConnection)dcMUPView.Connection;
        command.Connection.Open();
        command.Prepare();
        SqlDataAdapter adapter = new SqlDataAdapter(command);
        DataSet ds = new DataSet ();
        adapter.Fill(ds);
        command.Connection.Close();
        return ds;
    }

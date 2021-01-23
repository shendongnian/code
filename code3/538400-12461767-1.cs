    public void Part2(Action<DataTable> callback, ErrorHandler error)
    {
        SqlConnection conn = new SqlConnection(SqlConnectionString);
        SqlCommand cmd = conn.CreateCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "Part2";
        try
        {
            conn.Open();
        }
        catch (Exception ex)
        {
            error(ex.ToString());
            return;
        }
        CommandAndCallback<Action<DataTable>> ar = new CommandAndCallback<Action<DataTable>>() { Callback = callback, Error = error, Sql = cmd };
        IAsyncResult result = cmd.BeginExecuteReader(new AsyncCallback(Part2_Handler), ar, CommandBehavior.CloseConnection);
    }

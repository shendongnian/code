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
            private void Part2_Handler(IAsyncResult result)
        {
            DataTable dt = new DataTable();
            CommandAndCallback<Action<DataTable>> ar = (CommandAndCallback<Action<DataTable>>)result.AsyncState;
            SqlDataReader dr;
            if (result.IsCompleted)
            {
                dr = ar.Sql.EndExecuteReader(result);
            }
            else
                dr = null;
            dt.Load(dr);
            dr.Close();
            dt.Columns[3].ReadOnly = false;
            ar.Callback(dt);
        }

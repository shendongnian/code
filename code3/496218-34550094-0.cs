    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
    {
        var rowsAffected = -1;
        adapter.SelectCommand.StatementCompleted += delegate (object sender, StatementCompletedEventArgs e)
        {
            rowsAffected = e.RecordCount;
        };
        DataSet dt = new DataSet();
        adapter.Fill(dt); // Do something with DataTable
        return dt;
    }

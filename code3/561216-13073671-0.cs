    public MyTypedDataset GetMyDataSet()
    {
        MyTypedDataset ds = new MyTypedDataset();
        using (SqlConnection conn = new SqlConnection(connectionString))
        using (SqlCommand cmd = new SqlCommand("dbo.StoredProc1", conn))
        {
            cmd.CommandType = CommandType.StoredProcedure;
            IDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(ds.Table1);
            return result;
        }
    }

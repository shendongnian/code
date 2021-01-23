    DataSet1.TestDataTable DT = new DataSet1.TestDataTable();
    // Fill data table
    DataTable DT1 = DT;  // DataSet1.TestDataTable should be a subclass of DataTable
    using (SqlCommand command = new SqlCommand("MergeTest", connection))
    {
        command.CommandType = CommandType.StoredProcedure;
        command.Parameters.AddWithValue("@Testing", DT1);
        command.ExecuteNonQuery();
    }

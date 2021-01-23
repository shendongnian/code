    DataSet dset = new DataSet();
    using (SqlDataAdapter adapter = new SqlDataAdapter(statement, connection))
    {
          adapter.Fill(dset);
    }
    DataTable dtResults = dset.Tables[0];

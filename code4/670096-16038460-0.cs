    DataTable x = new DataTable(); 
    cmdGetRow("select * from employee;", ref x);
    
    public void cmdGetRow(String SQL, ref table)
    {
        NpgsqlDataAdapter NpAdapter = new NpgsqlDataAdapter();
        DataSet dset = new DataSet("hr");
        NpAdapter.SelectCommand = new NpgsqlCommand(SQL, dbConnection);
        NpAdapter.Fill(dset, "employee");
        table = dset.Tables["employee"];
    }

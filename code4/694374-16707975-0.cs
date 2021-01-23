    if(!string.IsNullOrWhiteSpace(myComm))
    {
        myCommand.CommandText = myComm;
        SqlDataAdapter dataAdapter = new SqlDataAdapter();
        dataAdapter.SelectCommand = myCommand;
        DataSet ds = new DataSet();
        dataAdapter.Fill(ds, "View2");
        dataGridView1.DataSource = ds.Tables["View2"].DefaultView;
    }

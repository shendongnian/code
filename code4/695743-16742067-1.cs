    var parameters = new string[PID.Length];
    var selectAll = new SqlCommand();
    
    for (int i = 0; i < PID.Length; i++)
    {
        parameters[i] = string.Format("@Age{0}", i);
        selectAll .Parameters.AddWithValue(parameters[i], PID[i]);
    }
    
    selectAll.CommandText = string.Format("SELECT * from Property p WHERE p.id IN ({0})", string.Join(", ", parameters));
    selectAll.Connection = connString;
    connString.Open();
    
    SqlDataAdapter adapter = new SqlDataAdapter();
    adapter.SelectCommand = selectAll;
    DataSet ds = new DataSet();
    adapter.Fill(ds);
    
    connString.Close();
    DataTable table = ds.Tables[0];

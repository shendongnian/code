    SqlDataReader dReader;
    SqlConnection conn = new SqlConnection(MyClass.GlobalConn());
    conn.Open();
    SqlCommand cmd = new SqlCommand();
    cmd.Connection = conn;
    cmd.CommandType = CommandType.Text; 
    cmd.CommandText = "select RTRIM(Person_name) from MyTable order by Person_name";
    dReader = cmd.ExecuteReader();
    cmd.CommandText = "select RTRIM(Person_number) from MyTable order by Person_number";
    dReader = cmd.ExecuteReader();
    if (dReader.HasRows == true)
    {
        while (dReader.Read())
            namesCollection.Add(dReader[0].ToString());
    }
    else
    {
        MessageBox.Show("Data not found");
    }
    dReader.Close();
    tPT.AutoCompleteMode = AutoCompleteMode.Suggest;
    tPT.AutoCompleteSource = AutoCompleteSource.CustomSource;
    tPT.AutoCompleteCustomSource = namesCollection;
    conn.Close();

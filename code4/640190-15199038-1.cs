    string check = "select * from custdetails where billid = @billid ";
    SqlCommand cmd1 = new SqlCommand();
    // use the command object to copy table first....
    cmd1.Connection = conn;
    cmd1.CommandText = "INSERT INTO table2 (SELECT * FROM  table1 WHERE billid = @billid)";
    cmd1.ExecuteNonQuery();
    //then continue doing the normal work
    cmd1.CommandText = check;
    cmd1.Parameters.AddWithValue("@billid", billid);
    DataSet ds = new DataSet();
    SqlDataAdapter da = new SqlDataAdapter(cmd1);
    da.Fill(ds);
    // string str1;
    int count = ds.Tables[0].Rows.Count;
    if (count > 0)
    {
        string str1 = ds.Tables[0].Rows[0][""].ToString();
    }

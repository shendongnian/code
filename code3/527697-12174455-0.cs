    SqlConnection con = new SqlConnection();
    con.ConnectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=answers;Integrated Security=True";
    
    SqlCommand cmd = new SqlCommand();
    cmd.Connection = con;
    cmd.CommandType = CommandType.StoredProcedure;   // ***ADD THIS LINE HERE****
    
    cmd.CommandText = "GetRowCount";
    cmd.Parameters.Add(new SqlParameter("@count", SqlDbType.Int));
    cmd.Parameters["@count"].Direction = ParameterDirection.Output;
    con.Open();
    SqlDataReader reader=cmd.ExecuteReader();
    int ans = (int)cmd.Parameters["@count"].Value;
    Console.WriteLine(ans);

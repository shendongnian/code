    using (SqlConnection con = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=answers;Integrated Security=True"))
    using (SqlCommand cmd = new SqlCommand("dbo.GetRowCount", con))
    {
        cmd.CommandType = CommandType.StoredProcedure;
                
        cmd.Parameters.Add(new SqlParameter("@count", SqlDbType.Int));
        cmd.Parameters["@count"].Direction = ParameterDirection.Output;
                
        con.Open();
        SqlDataReader reader = cmd.ExecuteReader();
        int ans = (int)cmd.Parameters["@count"].Value;
        con.Close();
        Console.WriteLine(ans);
    }

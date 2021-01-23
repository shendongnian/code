    using(SqlConnection con = New SqlConnection("ConnectionString")
    {
       SqlCommand cmd = new SqlCommand("Prefix_SomeProcName", con);
       cmd.CommandType = CommandType.StoredProcedure;
       var output = new SqlParameter() { Direction = ParameterDirection.Output, ParameterName = "@Output" };
       //Add your other parameters
       SqlDataAdapter sda = new SqlDataAdapter(cmd);
       DatatTable dt = New DataTable();
       sda.Fill(dt);
    }

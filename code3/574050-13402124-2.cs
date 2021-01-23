    DataTable table = new DataTable();
    using(var con = new SqlConnection(ConfigurationManager.ConnectionStrings["DB"].ConnectionString))
    using(var cmd = new SqlCommand("usp_GetABCD", con))
    using(var da = new SqlDataAdapter(cmd))
    {
       cmd.CommandType = CommandType.StoredProcedure;
       da.Fill(table);
    }

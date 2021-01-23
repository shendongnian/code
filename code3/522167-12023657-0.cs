    static public DataTable searchIt(string STR)
    {
        string connectionString =  McFarlaneIndustriesPOSnamespace.Properties.Settings.Default.McFarlane_IndustriesConnectionString;
        SqlConnection con = new SqlConnection(connectionString);
        DataTable DT = new DataTable();
        con.Open();
        SqlCommand command = new SqlCommand("Name_of_Your_Stored_Procedure",con);
        cmd.CommadType=CommandType.StoredProcedure;
        cmd.Parameters.Add(new SqlParameter("@parameter_name",SqlDbType.Varchar));
        cmd.Parameters[0].Value="your value";
        SqlDataAdapter DA = new SqlDataAdapter(cmd);
        DA.Fill(DT);
        con.Close();
        return DT;
    }

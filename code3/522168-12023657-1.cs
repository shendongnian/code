    static public DataTable searchIt(string STR)
    {
        string connectionString =  McFarlaneIndustriesPOSnamespace.Properties.Settings.Default.McFarlane_IndustriesConnectionString;
        SqlConnection con = new SqlConnection(connectionString);
        DataTable DT = new DataTable();
        con.Open();
        SqlCommand command = new SqlCommand("Name_of_Your_Stored_Procedure",con);
        command.CommandType=CommandType.StoredProcedure;
        command.Parameters.Add(new SqlParameter("@parameter_name",SqlDbType.NVarChar));
        command.Parameters[0].Value="Your Value in this case STR";
        SqlDataAdapter DA = new SqlDataAdapter(command);
        DA.Fill(DT);
        con.Close();
        return DT;
    }

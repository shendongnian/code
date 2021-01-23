    public DataTable BindGridView(string rgn)
    {
        string spdName = "spd_get_default_region";
        DbCommand cmd = m_WorkoutPortal_DB.GetStoredProcCommand(spdName);
        m_WorkoutPortal_DB.AddInParameter(cmd, "Rgn", DbType.String, rgn);
        SqlDataAdapter da = new SqlDataAdapter(cmd); // Create a SQL Data Adapter and assign it the cmd value. 
        
        DataTable dt = new DataTable(); // Create a new Data table
        da.Fill(dt); // Fill the data table with the results from the query
       
        return dt; // return the data table
     }

    // setup connection and command
    using (SqlConnection conn = new SqlConnection(-your-connection-string-here-))
    using (SqlCommand cmd = new SqlCommand("dbo.p_Defect_B", conn))
    {
        // define command as stored procedure
        cmd.CommandType = CommandType.StoredProcedure;
        
        // define and set parameter values
        cmd.Parameters.Add("@dtFrom", SqlDbType.DateTime).Value = new DateTime(2013, 5, 20);
        cmd.Parameters.Add("@dtFrom", SqlDbType.DateTime).Value = new DateTime(2013, 5, 25, 23, 59, 59);
        
        // execute your query
        conn.Open();
        // get a data reader to read the values from the result set
        using (SqlDataReader rdr = cmd.ExecuteReader())
        {
            // iterate over the result set
            while (rdr.Read())
            {
                // fetch the values - depends on your result set - YOU NEED TO ADAPT THIS!
                var value1 = rdr.GetInt(0);
                var value2 = rdr.GetString(1);
                ......
            }
            
            rdr.Close();
        }
        
        conn.Close();
    }

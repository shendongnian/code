    using (OracleConnection con = new OracleConnection(constr))
    {
        con.Open();
        using (OracleCommand cmd = con.CreateCommand())
        {
            cmd.CommandText = "select country_name from hr.countries where country_id = :country_id";
            cmd.Parameters.Add("country_id", "UK")
            OracleDataReader dr = cmd.ExecuteReader();
            if (dr.Read()) 
           { 
                // You code here
           }
        }
    }
        

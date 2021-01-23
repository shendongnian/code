    List<DateTime> dates = new List<DateTime>();
    
    using(SqlCommand cmd = new SqlCommand("SELECT holiday FROM holidays1", conn))
    using(SqlDataReader rdr = cmd.ExecuteReader()) {
        
        while( rdr.Read() ) {
            
            dates.Add( rdr.GetDateTime(0) );
        }
    }
    
    return dates;

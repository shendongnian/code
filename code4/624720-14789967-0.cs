    Structure your code so that your connections, commands, readers, etc... get closed or disposed of automatically. See example below.
    
    using (SqlConnection conn = new SqlConnection(--Conn String Here--)
    {
        using (SqlCommand cmd = conn.CreateCommand())
        {
            // Set Conn Properties Here
            Conn.Open();
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
    
            } // Reader automatically disposed here
        }
    } // Conn automatically closed here

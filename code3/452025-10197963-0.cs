    using (SqlConnection connection = new SqlConnection("...")) {
        connection.Open();
        string sql = "SQL command HERE";
    
        using (SqlCommand cmd = new SqlCommand(sql, con))
        using (SqlDataReader reader = cmd.ExecuteReader()) {
                // do your stuff
        }
    }

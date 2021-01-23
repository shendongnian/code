    I combine the use of params with HtmlEncoding(to get rid of special characters where not needed). Give that a shot.
    
    using (SqlConnection conn = new SqlConnection(conString))
    {     
        string sql = "SELECT * FROM table WHERE id = @id";
        using (SqlCommand cmd = new SqlCommand(sql, conn))
        {
            cmd.paramaters.AddWithValue("@id", System.Net.WebUtility.HtmlEncode(id));
            conn.Open();
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
    
            }
        }
    }

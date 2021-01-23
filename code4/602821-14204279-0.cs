    using (SqlConnection con = new SqlConnection(SqlConString))
    {
        string command = "Your Query Here...";
        using (SqlCommand cmd = new SqlCommand(command, con))
        {
            cmd.Parameters.AddWithValue("@Param", SqlDbType.Type).Value = YourParameter;
            con.Open();
            using (SqlDataAdapter da = cmd.ExecuteNonQuery())
            {
                da.Fill(dt);
            }
        }
    }

    using (SqlConnection conn = new SqlConnecction(connStr))
    {
        conn.Open();
        string qry = "INSERT TargetTable (TargetColumn) VALUES (@TextValue)";
        using (SqlCommand cmd = new SqlCommand(qry, conn))
        {
            cmd.Parameters.Add(new SqlParameter("@TextValue", textBox.Text.IsNullOrWhiteSpace() ? DBNull.Value : textBox.Text));
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (SqlException sex)
            {
                // whatever
            }
        }
    }

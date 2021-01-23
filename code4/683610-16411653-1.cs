    using (SqlConnection conn = new SqlConnecction(connStr))
    {
        conn.Open();
        string qry = "INSERT TargetTable (TargetColumn) VALUES (@TextValue)";
        using (SqlCommand cmd = new SqlCommand(qry, conn))
        {
            cmd.Parameters.Add(new SqlParameter("@TextValue", String.IsNullOrEmptyOrWhiteSpace(textBox.Text) ? DBNull.Value : textBox.Text));
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

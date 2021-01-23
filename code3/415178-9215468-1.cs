    using (SqlConnection conn = new SqlConnection(CMS.SettingsProvider.SqlHelperClass.ConnectionString))
    {
        conn.Open();
        using(SqlCommand command = new SqlCommand("SELECT...", conn))
        {
            using(SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        <snip>
                        build item IDs to update
                    }
                    UpdateRecords(conn, itemIDs);
                }
            }
        }
    }

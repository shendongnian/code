    using (SqlCommand cmd = new SqlCommand("SELECT DateColumn FROM Table", conn))
    using (SqlDataReader reader = cmd.ExecuteReader())
    {
        while (reader.Read())
        {
            DateTime datecolumn = reader["DateColumn"] as DateTime? ?? DateTime.MinValue;
            if (dateColumn.Date == DateTime.Now.Date)
            {
                ...
            }
        }
    }

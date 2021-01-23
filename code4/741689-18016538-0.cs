    using (var conn = new SqlConnection())
    {
        conn.Open();
        var command = new SqlCommand(selectStatement, conn);
        using (var rdr = command.ExecuteReader())
        {
            rdr.Read();
            int i = 0;
            while (i < rdr.FieldCount)
            {
                textControls[i].Text = rdr.GetString(i++);
            }
        }
    }

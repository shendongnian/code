    using (MySqlConnection c = new MySqlConnection("cstring"))
    {
        c.Open();
        var t = c.BeginTransaction();
        try
        {
            foreach (var o in list)
            {
                using (MySqlCommand cmd = new MySqlCommand("EXECUTE sp @field1, @field2", c, t))
                {
                    cmd.Parameters.AddWithValue("@field1", o.field1);
                    cmd.Parameters.AddWithValue("@field2", o.field2);
                    cmd.ExecuteNonQuery();
                }
            }
            t.Commit();
        }
        catch (Exception ex)
        {
            t.Rollback();
            // do something with ex
        }
    }

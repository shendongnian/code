    var list = new List<MyObject>();
    using (SqlConnection c = new SqlConnection("your connection string"))
    {
        var cmd = new SqlCommand("EXEC [dbo].myProcedure", c);
        cmd.CommandType = CommandType.StoredProcedure;
        using (SqlDataReader sdr = cmd.ExecuteReader())
        {
            while (sdr.Read())
            {
                var o = new MyObject
                {
                    Property1 = sdr.GetString(0),
                    Property2 = sdr.GetInt32(1),
                    etc...
                }
                list.Add(o);
            }
        }
    }

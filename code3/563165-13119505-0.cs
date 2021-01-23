    using(var conn = GetAnOpenConnection())
    using(var cmd = conn.CreateCommand())
    {
        cmd.CommandText = ...
        cmd.Parameters.Add(...);
        using(var reader = cmd.ExecuteReader())
        {
            var control = getSupplierNumber(reader);
        }
    }

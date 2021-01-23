    foreach (SqlParameter param in p)
    {
        if (param.Value == null)
        {
               param.Value = DBNull.Value;
        }
        cmd.Parameters.Add(param);
    }

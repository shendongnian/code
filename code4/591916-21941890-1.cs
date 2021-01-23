    using (SqlCommand cmd = new SqlCommand())
    {
        SqlParameter sqlParameter = cmd.CreateParameter();
        sqlParameter.Direction = System.Data.ParameterDirection.Input;
        sqlParameter.Value = new System.Data.SqlTypes.SqlXml(xmlReader);
        ...
    }

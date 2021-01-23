    if (reader.IsDBNull(i))
    {
        cellValue = "NULL";
    }
    else
    {
        OracleLob clob = reader.GetOracleLob(i);
        cellValue  = (string) clob.Value;
    }

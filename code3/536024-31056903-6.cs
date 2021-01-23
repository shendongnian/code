    string _AuditSQL = @"
        INSERT INTO TestDB2.dbo.AuditLog (BeforeValue, AfterValue)
            SELECT del.Something, ins.Something
            FROM   INSERTED ins
            FULL OUTER JOIN DELETED del
                         ON del.Id = ins.Id;
    ";
    
    SqlConnection _Connection = new SqlConnection("Context Connection = true");
    SqlCommand _Command = _Connection.CreateCommand();
    _Command.CommandText = _AuditSQL;
    
    try
    {
        _Connection.Open();
        _Command.ExecuteNonQuery();
    }
    finally
    {
        _Command.Dispose();
        _Connection.Dispose();
    }

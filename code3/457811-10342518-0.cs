    using (OracleConnection conn = new OracleConnection(m_fceConn))
    {
        conn.Open();
    
        using (OracleDataReader reader = new OracleCommand(m_sql, conn).ExecuteReader())
        {
            reader.Read();
        }
    
        conn.Close();
    }

    public IEnumerable<IDataRecord> localfetchrows(string query, List<MySqlParameter> dbparams = null)
    {
        using (var conn = connectLocal())
        {
            MySqlCommand sql = conn.CreateCommand();
            sql.CommandText = query;
            if (dbparams != null)
            {
                if (dbparams.Count > 0)
                {
                    sql.Parameters.AddRange(dbparams.ToArray());
                }
            }
            using (IDataReader rdr = sql.ExecuteReader())
            {
                while (rdr.Read())
                {
                    yield return (IDataRecord)rdr;
                }
            }
        }
    }

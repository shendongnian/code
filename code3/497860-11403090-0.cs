    public DataSet localfetchrows(string query, List<MySqlParameter> dbparams = null) 
    { 
        DataSet ds;
        using (var conn = connectLocal()) 
        { 
            Console.WriteLine("Connecting local : " + conn.ServerVersion); 
            MySqlCommand sql = conn.CreateCommand(); 
            sql.CommandText = query; 
            if (dbparams != null) 
            { 
                if (dbparams.Count > 0) 
                { 
                    sql.Parameters.AddRange(dbparams.ToArray()); 
                } 
            } 
            MySqlDataReader reader = sql.ExecuteReader(); 
            Console.WriteLine("Reading data : " + reader.HasRows + reader.FieldCount); 
            reader.Fill(ds);
            return ds; 
        }
    }

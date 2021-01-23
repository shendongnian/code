    public IEnumerable<T> ExecuteReader<T>(SqlCommand cmd, 
        Func<IDataRecord, T> recordCreator)
    {
        using (var con = GetConnection()) {
            con.Open ();
            using (var tr = con.BeginTransaction()) {
                cmd.Connection = con;
                var reader = cmd.ExecuteReader();
                while (reader.Read()) {
                    yield return recordCreator(reader);
                }
                tr.Commit();
            }
        }
    }

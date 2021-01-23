    var reader = ExecuteReader(new SqlCommand("SELECT ColumnA, ColumnB FROM Table"));
    string ColA = string.empty;
    string ColB = string.empty;
    while (reader.Read())
           ColA = reader["ColumnA"].ToString();
           ColB = reader["ColumnB"].ToString();
    reader.Close();
    reader.Dispose();

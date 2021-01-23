    SQLiteConnectionStringBuilder builder = new SQLiteConnectionStringBuilder();
    builder.FailIfMissing = true;
    builder.DataSource = "Insert the fully qualified path to your sqlite db";
    SQLiteConnection connection = new SQLiteConnection(builder.ConnectionString);
    try
    {
      connection.Open();
    }
    catch(SqlException exp)
    {
        // Log what you need from here.
        throw new InvalidOperationException("Whatever exception you want to throw", exp);
    }

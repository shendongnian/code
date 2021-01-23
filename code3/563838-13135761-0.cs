    using (SqlConnection conn = new SqlConnection(connectionStr) )
    {
        var sqlCmd = "
                      CREATE TABLE #tmp (
                          InsertedId BIGINT                                             
                      );
                      INSERT INTO TestTable
                      OUTPUT Inserted.Id INTO #tmp
                      VALUES ....
                      SELECT COUNT(*) FROM #tmp";
        using(SqlCommand cmd = new SqlCommand(sqlCmd,conn))
        {
            conn .Open();
            var numRows = command.ExecuteNonQuery();
            Console.WriteLine("Affected Rows: {0}",numRows);
        }
    }

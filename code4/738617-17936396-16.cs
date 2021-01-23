        const string fileName = "myData.xlsx";
        const int chunkSize = 100;
        using (
            var cnn =
                new OleDbConnection("provider=Microsoft.ACE.OLEDB.12.0;Data Source='" + fileName +
                                    "';Extended Properties=Excel 12.0;"))
        {
            cnn.Open();
            const string countQuery = "SELECT COUNT(*) FROM [Detail$]";
            using (var cmd = new OleDbCommand(countQuery, cnn))
            {
                using (OleDbDataReader reader = cmd.ExecuteReader())
                {
                    if (reader == null) return;
                    reader.Read();
                    int rowsCount = ((int)reader[0]) + 1;
                    const string query = "SELECT * FROM [Detail$]";
                    var odp = new OleDbDataAdapter(query, cnn);
                    var detailTable = new DataTable();
                    const int maxRecordsToFetch = chunkSize;
                    int recordToStartFetchFrom = 0; //The zero-based record number to start with.
                    while (recordToStartFetchFrom <= rowsCount)
                    {
                        odp.Fill(recordToStartFetchFrom, maxRecordsToFetch, detailTable);
                        foreach (DataRow row in detailTable.Rows)
                        {
                            Console.WriteLine("{0}-{0}", row.ItemArray[0]);
                        }
                        Console.WriteLine("------------------------{0}-{1} CHUNK---------------------------", recordToStartFetchFrom, recordToStartFetchFrom + chunkSize);
                        int totalLeftItemsToProcess = rowsCount - recordToStartFetchFrom;
                        int dummyResult = (totalLeftItemsToProcess >= chunkSize || totalLeftItemsToProcess == 0)
                                              ? recordToStartFetchFrom += chunkSize
                                              : recordToStartFetchFrom += totalLeftItemsToProcess;
                        detailTable.Dispose();
                        detailTable = null;
                        detailTable = new DataTable();
                    }
                    Console.ReadLine();

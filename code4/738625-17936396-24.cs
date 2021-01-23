            const string fileName = "myData.xlsx";
            const string excelConnString = "provider=Microsoft.ACE.OLEDB.12.0;Data Source='" + fileName + "';Extended Properties=Excel 12.0;";
            using (var cnn = new OleDbConnection(excelConnString))
            {
                cnn.Open();
                const string countQuery = "SELECT COUNT(*) FROM [Detail$]";
                using (var cmd = new OleDbCommand(countQuery, cnn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader == null) return;
                        reader.Read();
                        var rowsCount = ((int)reader[0]);
                        const string query = "SELECT * FROM [Detail$]";
                        using (var odp = new OleDbDataAdapter(query, cnn))
                        {
                            var detailTable = new DataTable();
                            var recordToStartFetchFrom = 0; //zero-based record number to start with.
                            const int chunkSize = 100;
                            while (recordToStartFetchFrom <= rowsCount)
                            {
                                var diff = rowsCount - recordToStartFetchFrom;
                                int internalChunkSize = diff < 100 ? diff : chunkSize;
                                odp.Fill(recordToStartFetchFrom, internalChunkSize, detailTable);
                                foreach (DataRow row in detailTable.Rows)
                                {
                                    Console.WriteLine("{1} {0}", row.ItemArray[0], row.ItemArray[1]);
                                }
                                Console.WriteLine("--------- {0}-{1} Rows Processed ---------", recordToStartFetchFrom, recordToStartFetchFrom + internalChunkSize);
                                recordToStartFetchFrom += chunkSize;
                                detailTable.Dispose();
                                detailTable = null;
                                detailTable = new DataTable();
                            }
                        }
                        Console.ReadLine();
                    }
                }
            }

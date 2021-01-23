            const string fileName = "myData.xlsx";
            string excelConnString = "provider=Microsoft.ACE.OLEDB.12.0;Data Source='" + fileName + "';Extended Properties=Excel 12.0;";
            using (var cnn =new OleDbConnection(excelConnString))
            {
                cnn.Open();
                const string countQuery = "SELECT COUNT(*) FROM [Detail$]";
                using (var cmd = new OleDbCommand(countQuery, cnn))
                {
                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader == null) return;
                        reader.Read();
                        int rowsCount = ((int)reader[0]);
                        const string query = "SELECT * FROM [Detail$]";
                        var odp = new OleDbDataAdapter(query, cnn);
                        var detailTable = new DataTable();
               
                        int recordToStartFetchFrom = 0; //zero-based record number to start with.
                        int chunkSize = 100;
                        while (recordToStartFetchFrom <= rowsCount)
                        {
                            odp.Fill(recordToStartFetchFrom, chunkSize, detailTable);
                            foreach (DataRow row in detailTable.Rows)
                            {
                                Console.WriteLine("{0}-{0}", row.ItemArray[0]);
                            }
                            Console.WriteLine("-----------------------{0}-{1} Processed-------------------------", recordToStartFetchFrom, recordToStartFetchFrom+chunkSize);
                            
                            recordToStartFetchFrom += chunkSize;
                            detailTable.Dispose();
                            detailTable = null;
                            detailTable = new DataTable();
                        }
                        Console.ReadLine();
                    }
                }
            }

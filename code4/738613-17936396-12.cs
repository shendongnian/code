            const string fileName = "myData.xlsx";
            const int maxRecordsToFetch = 100;
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
                        int rowsCount = (int) reader[0];
                        
                        const string query = "SELECT * FROM [Detail$]";
                        var odp = new OleDbDataAdapter(query, cnn);
                        var detailTable = new DataTable();
                        int fetchedItems = 0; //The zero-based record number to start with.
                        while (fetchedItems < rowsCount)
                        {
                            odp.Fill(fetchedItems, maxRecordsToFetch, detailTable);
                            //Do your data job right here, remember that you have
                            //a chunk of 100 records per iteration!
                            
                            //Clean your temp data-table to avoid of memory leaks
                            detailTable.Clear();
                            detailTable.Dispose();
                            detailTable = null;
                            detailTable = new DataTable();
                            fetchedItems += 100;
                        }
                    }
                }
            }

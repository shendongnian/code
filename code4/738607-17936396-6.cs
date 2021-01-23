            const string fileName = "myData.xlsx";
            const int maxRecordsToFetch = 100;
            using (
                var cnn =
                    new OleDbConnection("provider=Microsoft.ACE.OLEDB.12.0;Data Source='" + fileName +
                                        "';Extended Properties=Excel 12.0;"))
            {
                cnn.Open();
                const string query = "SELECT * FROM [Detail$]";
                using (var cmd = new OleDbCommand(query, cnn))
                {
                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader == null) return;
                        int rowsCount = 0;
                        while (reader.Read())
                        {
                            rowsCount += 1;
                        }
                        var odp = new OleDbDataAdapter(query, cnn);
                        var detailTable = new DataTable();
                        int fetchedItems = 0; //The zero-based record number to start with.
                        while (fetchedItems < rowsCount)
                        {
                            odp.Fill(fetchedItems, maxRecordsToFetch, detailTable);
                            //Do your job here!!! { }
                            detailTable.Clear();
                            detailTable = null;
                            detailTable = new DataTable();
                            fetchedItems += 100;
                        }
                    }
                }
            }

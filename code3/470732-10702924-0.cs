    string ConnectionString = string.Format(@"Provider=Microsoft.Jet.OLEDB.4.0; Data Source={0}; Extended Properties=""Excel 8.0;HDR=Yes"";", fileName);
    
                using (OleDbConnection conn = new OleDbConnection(ConnectionString))
                {
                    conn.Open();
                    DataTable schemaTable = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
    
                    foreach (DataRow schemaRow in schemaTable.Rows)
                    {
                        string sheet = schemaRow["TABLE_NAME"].ToString();
                        using (OleDbCommand cmd = new OleDbCommand("SELECT * FROM [" + sheet + "]", conn))
                        {
                            cmd.CommandType = CommandType.Text;
                            DataTable outputTable = new DataTable(sheet);
                            output.Tables.Add(outputTable);
                            new OleDbDataAdapter(cmd).Fill(outputTable);
                        }
                    }
                    conn.Close();
                }

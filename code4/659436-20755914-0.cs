    public DataTable QueryToTable(Entities db, string queryText, SqlParameter[] parametes)
            {
                using ( DbDataAdapter adapter = new SqlDataAdapter())
                using (adapter.SelectCommand = db.Database.Connection.CreateCommand())
                {
                    adapter.SelectCommand.CommandText = queryText;
                    if (parametes != null)
                        adapter.SelectCommand.Parameters.AddRange(parametes);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    return table;
                }
            }

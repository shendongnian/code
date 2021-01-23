    public DataTable GetTable(string table_name)
    {
        table = null;
        if (conn_str != null)
        {
            try
            {
                using (OdbcConnection conn = new OdbcConnection(conn_str.ToString()))
                {
                    StringBuilder query = new StringBuilder();
                    query.Append("SELECT * ");
                    query.Append("FROM [");
                    query.Append(table_name + "]");
                    using (OdbcCommand cmd = new OdbcCommand(query.ToString(), conn))
                    {
                        conn.Open();
                        table = new DataTable();
                        using (OdbcDataReader dr = cmd.ExecuteReader())
                        {
                            DataSet ds = new DataSet();
                            ds.EnforceConstraints = false;
                            ds.Tables.Add(table);
                            table.Load(dr);
                            foreach (DataColumn col in table.Columns)
                            {
                                //Fix column names if the Reader insert the table name into the ColumnName
                                col.ColumnName = col.ColumnName.Replace(table_name + ".", "");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.Print(ex.Message);
                table = null;
            }
        }
        return table;
    }

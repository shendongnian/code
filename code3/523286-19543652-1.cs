        public static void DataSetsToExcel(DataSet dataSet, string filepath)
        {
            try
            {
                string connString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filepath + ";Extended Properties=Excel 12.0 Xml;";
                string tablename = "";
                DataTable dt = new DataTable();
                foreach (System.Data.DataTable dataTable in dataSet.Tables)
                {
                    dt = dataTable;
                    tablename = dataTable.TableName;
                    using (OleDbConnection con = new OleDbConnection(connString))
                    {
                        con.Open();
                        StringBuilder strSQL = new StringBuilder();
                        strSQL.Append("CREATE TABLE ").Append("[" + tablename + "]");
                        strSQL.Append("(");
                        for (int i = 0; i < dt.Columns.Count; i++)
                        {
                            strSQL.Append("[" + dt.Columns[i].ColumnName + "] text,");
                        }
                        strSQL = strSQL.Remove(strSQL.Length - 1, 1);
                        strSQL.Append(")");
                        OleDbCommand cmd = new OleDbCommand(strSQL.ToString(), con);
                        cmd.ExecuteNonQuery();
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            strSQL.Clear();
                            StringBuilder strfield = new StringBuilder();
                            StringBuilder strvalue = new StringBuilder();
                            for (int j = 0; j < dt.Columns.Count; j++)
                            {
                                strfield.Append("[" + dt.Columns[j].ColumnName + "]");
                                strvalue.Append("'" + dt.Rows[i][j].ToString().Replace("'", "''") + "'");
                                if (j != dt.Columns.Count - 1)
                                {
                                    strfield.Append(",");
                                    strvalue.Append(",");
                                }
                                else
                                {
                                }
                            }
                            if (strvalue.ToString().Contains("<br/>"))
                            {
                                strvalue = strvalue.Replace("<br/>", Environment.NewLine);
                            }
                            cmd.CommandText = strSQL.Append(" insert into [" + tablename + "]( ")
                                .Append(strfield.ToString())
                                .Append(") values (").Append(strvalue).Append(")").ToString();
                            cmd.ExecuteNonQuery();
                        }
                        con.Close();
                    }
                }
            }
            catch (Exception ex)
            {                
            }
        }

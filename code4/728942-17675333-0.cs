    foreach (DataTable dt in ds.Tables)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        foreach (DataColumn col in dt.Columns)
                        {
                            if (col.ColumnName == "colName"))
                            {
                                dr[col] = dr[col].ToString().Replace(" ", "");
                            }
                            else if (col.DataType == typeof(System.String))
                            {
                                dr[col] = dr[col].ToString().Trim();
                            }
                        }
                    }
                }

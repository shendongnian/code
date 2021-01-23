     foreach (DataRow dr in table.Rows)
            {
                foreach (DataColumn clm in table.Columns)
                {
                    if (dr[clm] == DBNull.Value)
                    {
                        dr[clm] = GetDefaultValueForColumn[clm.ColumnName];
                    }
                }
            }

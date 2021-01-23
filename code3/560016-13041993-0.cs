            DataSet dsMain = GetMyMainDataSet();
            DataSet dsTablesById = new DataSet();
            foreach (DataRow row in dsMain.Tables[0].Rows)
            {
                string storeId = row["storeid"].ToString();
                if (!dsTablesById.Tables.Contains(storeId))
                {
                    dsTablesById.Tables.Add(storeId);
                    foreach (DataColumn col in dsMain.Tables[0].Columns)
                    {
                        dsTablesById.Tables[storeId].Columns.Add(col.ColumnName, col.DataType);
                    }
                }
                dsTablesById.Tables[storeId].Rows.Add(row.ItemArray);
                dsTablesById.Tables[storeId].AcceptChanges();
            }

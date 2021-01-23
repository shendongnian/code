    ArrayList commonColumns = new ArrayList();
    for (int iServerColumnCount = 0; iServerColumnCount < oDtSeverData .Columns.Count; iServerColumnCount ++)
    {
      for (int iLocalColumnCount = 0;
                                 iLocalColumnCount < oDtLocalSystemData .Columns.Count;
                                 iLocalColumnCount ++)
        {
          if (oDtSeverData .Columns[iServerColumnCount ].ColumnName.ToString()
                 .Equals(oDtLocalSystemData .Columns[iLocalColumnCount].ColumnName.ToString()))
          {
             commonColumns.Add(oDtLocalSystemData .Columns[iLocalColumnCount].ColumnName.ToString());
          }
        }
    }
    DataTable oDtData = CompareTwoDataTable(oDtLocalSystemData, oDtSeverData,commonColumns);
    public DataTable CompareTwoDataTable(DataTable dtOriginalTable, DataTable dtNewTable, ArrayList columnNames)
        {
            DataTable filterTable = new DataTable();
            try
            {
                filterTable = dtNewTable.Copy();
                string filterCriterial;
                if (columnNames.Count > 0)
                {
                    for (int iNewTableRowCount = 0; iNewTableRowCount < dtNewTable.Rows.Count; iNewTableRowCount++)
                    {
                        filterCriterial = string.Empty;
                        foreach (string colName in columnNames.ToArray())
                        {
                           
                            filterCriterial += "ISNULL("+colName.ToString() + ",'')='" + dtNewTable.Rows[iNewTableRowCount][colName].ToString() + "' AND ";
                        }
                        filterCriterial = filterCriterial.TrimEnd((" AND ").ToCharArray());
                        DataRow[] dr = dtOriginalTable.Select(filterCriterial);
                        if (dr.Length > 0)
                        {
                            filterTable.Rows[filterTable.Rows.IndexOf(filterTable.Select(filterCriterial)[0])].Delete();
                            filterTable.AcceptChanges();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
           
            return filterTable;
        }

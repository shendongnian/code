    public DataTable CompareTwoDataTable(DataTable dtOriginalTable, DataTable dtNewTable, ArrayList columnNames)
        {
            DataTable filterTable = new DataTable();
            filterTable = dtNewTable.Copy();
            string filterCriterial;
            if (columnNames.Count > 0)
            {
                for (int iNewTableRowCount = 0; iNewTableRowCount < dtNewTable.Rows.Count; iNewTableRowCount++)
                {
                    filterCriterial = string.Empty;
                    foreach (string colName in columnNames.ToArray())
                    {
                        filterCriterial += colName.ToString() + "='" + dtNewTable.Rows[iNewTableRowCount][colName].ToString() + "' AND ";
                    }
                    filterCriterial = filterCriterial.TrimEnd((" AND ").ToCharArray());
                    DataRow[] dr = dtOriginalTable.Select(filterCriterial);
                    if (dr.Length > 0)
                    {
                        filterTable.Rows[filterTable.Rows.IndexOf(filterTable.Select(filterCriterial)[0])].Delete();
                    }
                }
            }
            return filterTable;
        }

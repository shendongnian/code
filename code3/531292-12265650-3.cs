    public static class DataTableExtensions
    {
        public static int IndexOf(this DataTable tblMain, DataTable tblSub, params String[] ignoreColumns)
        {
            if (tblMain == null)
                throw new ArgumentNullException("tblMain");
            if (tblSub.Rows.Count == 0)
                throw new ArgumentException("tblSub must not be empty", "tblSub");
            if (tblSub.Rows.Count > tblMain.Rows.Count)
                return -1;
            IEnumerable<String> relevantColumnNames = tblSub.Columns.Cast<DataColumn>()
                .Select(c => c.ColumnName)
                .Except(ignoreColumns)
                .ToArray();
            foreach (String colName in relevantColumnNames)
                if (!tblMain.Columns.Contains(colName))
                    return -1;
            IEnumerable<DataRow> allMainRows = tblMain.AsEnumerable();
            for (int mainRowIndex = 0; mainRowIndex < tblMain.Rows.Count; mainRowIndex++)
            {
                // check if current window is equal to tblSub
                bool allRowsAreEqual = true;
                for (int windowIndex = mainRowIndex; windowIndex < tblSub.Rows.Count + mainRowIndex; windowIndex++)
                {
                    DataRow currentMain = tblMain.Rows[windowIndex];
                    DataRow currentSub = tblSub.Rows[windowIndex - mainRowIndex];
                    bool allFieldsAreEqual = relevantColumnNames.All(colName =>
                        Object.Equals(currentMain[colName], currentSub[colName]));
                    if (!allFieldsAreEqual)
                    {
                        allRowsAreEqual = false;
                        break; // continue with next window in main-table
                    }
                }
                if (allRowsAreEqual)
                    return mainRowIndex;
            }
            // no equal window found in main-table
            return -1;
        }
    }

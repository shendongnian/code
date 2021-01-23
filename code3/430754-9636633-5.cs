    private void RemoveDuplicates(DataTable table, List<string> keyColumns)
    {
        Dictionary<string, string> uniquenessDict = new Dictionary<string, string>(table.Rows.Count);
        System.Text.StringBuilder sb = null;
        int rowIndex = 0;
        DataRow row;
        DataRowCollection rows = table.Rows;
        while (rowIndex < rows.Count) //Fix off-by-1 error.
        {
            row = rows[rowIndex];
            sb = new System.Text.StringBuilder();
            foreach (string colname in keyColumns)
            {
                sb.Append(((string)row[colname]));
            }
            if (uniquenessDict.ContainsKey(sb.ToString()))
            {
                rows.Remove(row);
            }
            else
            {
                uniquenessDict.Add(sb.ToString(), string.Empty);
                rowIndex++;
            }
        }
    }

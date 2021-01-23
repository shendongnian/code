    public static DataTable SearchInAllColums(this DataTable table, string keyword, StringComparison comparison)
    {
        if(keyword.Equals(""))
        {
            return table;
        }
        DataRow[] filteredRows = table.Rows
               .Cast<DataRow>()
               .Where(r => r.ItemArray.Any(
               c => c.ToString().IndexOf(keyword, comparison) >= 0))
               .ToArray();
        if (filteredRows.Length == 0)
        {
            DataTable dtProcessesTemp = table.Clone();
            dtProcessesTemp.Clear();
            return dtProcessesTemp;
        }
        else
        {
            return filteredRows.CopyToDataTable();
        }
    }

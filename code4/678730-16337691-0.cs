    public static DataTable Sort(this DataTable dt, string ColumnName, string param)
    {
        DataTable dtCopy = new DataTable();
        List<DataRow> list = dt.Rows.Cast<DataRow>().ToList();
        list.Sort((x, y) => Convert.ToString(x[ColumnName]).ToLower().IndexOf(param).CompareTo(Convert.ToString(y[ColumnName]).ToLower().IndexOf(param)));
        dtCopy = list.CopyToDataTable();
        return dtCopy;
    }

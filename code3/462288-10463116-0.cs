    private static double Calc(string expression)
    {
        try
        {
            var table = new System.Data.DataTable();
            table.Columns.Add("expression", string.Empty.GetType(), expression);
            System.Data.DataRow row = table.NewRow();
            table.Rows.Add(row);
            return double.Parse((string)row["expression"]);
        }
        catch (Exception)
        {
            return 0;
        }
    }
